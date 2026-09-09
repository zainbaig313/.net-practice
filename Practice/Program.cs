var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IMySerivce , MyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

// Remove HTTPS redirection so you can test with http

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public interface IMySerivce
{
    void LogCreation(string message);
}

public class MyService : IMySerivce
{
    private readonly int _serviceId ;

    public MyService()
    {
        _serviceId = new Random().Next(100000,9999999);
    }

    public void LogCreation(string message)
    {
        Console.WriteLine($"{message} with id : {_serviceId}");
    }
}