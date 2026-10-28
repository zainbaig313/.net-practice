
var builder = WebApplication.CreateBuilder(args);

// Register controller support
builder.Services.AddControllers();

builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();

// Map controller routes
app.MapControllers();

app.Run();
