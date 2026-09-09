using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers()
        .AddJsonOptions(options =>
{
   options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper; 
});


var app = builder.Build();

// Configure the HTTP request pipeline.

// Remove HTTPS redirection so you can test with http

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();