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


app.Use(async (context , next) =>
{
    
    if(context.Request.Path == "/unauthorized")
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Unauthorizewd access");
        return;
    }
   await next();
});


app.Use(async (context , next) =>
{
    var isAuthenticated  = context.Request.Query["authenticated"] == "true" ;
    if(!isAuthenticated)
    {
        context.Response.StatusCode = 403;
        await context.Response.WriteAsync("access denied");
        return;
    }
    context.Response.Cookies.Append("SecureCookie", "SecureData", new CookieOptions
    {
        HttpOnly = true,
        Secure = true,

    });
   await next();
});

app.Use(async (context, next) =>
{
    await Task.Delay(100);
    await context.Response.WriteAsync("process  asyncronus");
    await next();
});

static bool isValidInput(string input)
{
    return string.IsNullOrEmpty(input) ||
        (input.All(char.IsLetterOrDigit) && !input.Contains("<script>")); 
}
app.Run();

