using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>(); // 1. Error handling
app.UseMiddleware<AuthMiddleware>();          // 2. Authentication
app.UseMiddleware<LoggingMiddleware>();  

// Global error handling middleware
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsJsonAsync(new { error = "An unexpected error occurred." });
    });
});

// In-memory storage with pre-filled data
var users = new List<User>
{
    new User { Id = 1, Name = "Alice Johnson", Email = "alice.johnson@techhive.com", Department = "HR" },
    new User { Id = 2, Name = "Bob Smith", Email = "bob.smith@techhive.com", Department = "IT" },
    new User { Id = 3, Name = "Charlie Davis", Email = "charlie.davis@techhive.com", Department = "HR" },
    new User { Id = 4, Name = "Diana Lee", Email = "diana.lee@techhive.com", Department = "IT" }
};
var nextId = users.Max(u => u.Id) + 1;

// GET: /users
app.MapGet("/users", () => Results.Ok(users));

// GET: /users/{id}
app.MapGet("/users/{id}", (int id) =>
{
    if (id <= 0) return Results.BadRequest(new { error = "Invalid user ID." });
    var user = users.FirstOrDefault(u => u.Id == id);
    return user is not null ? Results.Ok(user) : Results.NotFound(new { error = "User not found." });
});

// POST: /users
app.MapPost("/users", (User newUser) =>
{
    var validationResults = ValidateUser(newUser);
    if (validationResults.Any())
        return Results.BadRequest(new { errors = validationResults });

    newUser.Id = nextId++;
    users.Add(newUser);
    return Results.Created($"/users/{newUser.Id}", newUser);
});

// PUT: /users/{id}
app.MapPut("/users/{id}", (int id, User updatedUser) =>
{
    if (id <= 0) return Results.BadRequest(new { error = "Invalid user ID." });

    var user = users.FirstOrDefault(u => u.Id == id);
    if (user is null) return Results.NotFound(new { error = "User not found." });

    var validationResults = ValidateUser(updatedUser);
    if (validationResults.Any())
        return Results.BadRequest(new { errors = validationResults });

    user.Name = updatedUser.Name;
    user.Email = updatedUser.Email;
    user.Department = updatedUser.Department;

    return Results.NoContent();
});
// Helper: Validate User
List<string> ValidateUser(User user)
{
    var results = new List<ValidationResult>();
    var context = new ValidationContext(user);
    Validator.TryValidateObject(user, context, results, true);
    return results.Select(r => r.ErrorMessage).ToList();
}

// DELETE: /users/{id}
app.MapDelete("/users/{id}", (int id) =>
{
    if (id <= 0) return Results.BadRequest(new { error = "Invalid user ID." });

    var user = users.FirstOrDefault(u => u.Id == id);
    if (user is null) return Results.NotFound(new { error = "User not found." });

    users.Remove(user);
    return Results.NoContent();
});

app.Run();

public class User
{
    public int Id { get; set; }

    [Required, MinLength(3)]
    public string Name { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    [RegularExpression("^(HR|IT)$", ErrorMessage = "Department must be HR or IT.")]
    public string Department { get; set; }
}

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new { error = "Internal server error." });
        }
    }
}
public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault();

        if (string.IsNullOrEmpty(token) || token != "valid-token")
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new { error = "Unauthorized" });
            return;
        }

        await _next(context);
    }
}
public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var method = context.Request.Method;
        var path = context.Request.Path;

        await _next(context);

        var statusCode = context.Response.StatusCode;
        Console.WriteLine($"[{DateTime.Now}] {method} {path} => {statusCode}");
    }
}
