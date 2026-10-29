using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddHangfire(configuration =>
    configuration.UseSqlServerStorage("Server=ZAIN-PC\\SQLEXPRESS;Database=Hangfire;Integrated Security=True;TrustServerCertificate=True;"));

builder.Services.AddHangfireServer();

var app = builder.Build();

// Register the Hangfire Dashboard middleware.
app.UseHangfireDashboard("/hangfire");

// Create a sample background job.

app.UseHttpsRedirection();
app.MapControllers();


app.Run();

