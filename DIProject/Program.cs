using Serilog;


var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File("logs/myapp.txt" , rollingInterval: RollingInterval.Day)

        .CreateLogger();


builder.Host.UseSerilog();


// Add services to the container.

builder.Services.AddControllers();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddSingleton<IMyService ,MyService>();

var app = builder.Build();


app.Use (async (context , next) =>
{
    try
    {
        await next();

    }
    catch(Exception ex)
    {
        Console.WriteLine($"Golobal exception caught : {ex}");
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("an unexpected erroroccured please try again .");
    }
});

app.Use(
    async (context , next) =>
    {
        var myService = context.RequestServices.GetRequiredService<IMyService>();
        myService.LogCreation("first  middleware");
        await next();
    }
);
// Configure the HTTP request pipeline.

// Remove HTTPS redirection so you can test with http

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();