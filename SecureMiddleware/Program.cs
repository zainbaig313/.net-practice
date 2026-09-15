var builder = WebApplication.CreateBuilder(args);


builder.WebHost.ConfigureKestrel(options =>
{
   options.ListenLocalhost(5294); 
});

var app  = builder.Build();

app.Use(async (context , next) =>
{
    if(context.Request.Query["secure"] != "true")
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("simulated hhtps requierd");
        return;
    }
   await next();
});

app.Use(async (context , next) =>
{
    var input  = context.Request.Query["input"];
    if(!isValidInput(input))
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("invald input");
        return;
    }
   await next();
});

static bool isValidInput(string input)
{
    return string.IsNullOrEmpty(input) ||
        (input.Aggregate;;)
}
app.Run();

