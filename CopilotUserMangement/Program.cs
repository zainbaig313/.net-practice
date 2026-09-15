using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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
app.MapGet("/users", () =>
{
    return Results.Ok(users);
});

// GET: /users/{id}
app.MapGet("/users/{id}", (int id) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);
    return user is not null ? Results.Ok(user) : Results.NotFound();
});

// POST: /users
app.MapPost("/users", (User newUser) =>
{
    newUser.Id = nextId++;
    users.Add(newUser);
    return Results.Created($"/users/{newUser.Id}", newUser);
});

// PUT: /users/{id}
app.MapPut("/users/{id}", (int id, User updatedUser) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);
    if (user is null) return Results.NotFound();

    user.Name = updatedUser.Name;
    user.Email = updatedUser.Email;
    user.Department = updatedUser.Department;

    return Results.NoContent();
});

// DELETE: /users/{id}
app.MapDelete("/users/{id}", (int id) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);
    if (user is null) return Results.NotFound();

    users.Remove(user);
    return Results.NoContent();
});

app.Run();

public class User
{
    public int Id { get; set; }          // Unique identifier
    public string Name { get; set; }     // Full name
    public string Email { get; set; }    // Email address
    public string Department { get; set; } // HR or IT
}
