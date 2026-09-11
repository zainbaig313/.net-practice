
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging( logging =>{
        logging.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
        logging.RequestBodyLogLimit =4096;
        logging.ResponseBodyLogLimit =4096;
});

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
// Add services to the container.

builder.Services.AddControllers();



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.Use(async (context , next) =>
{
    var startTime = DateTime.UtcNow;
   await next.Invoke(); 

   var totalTime = DateTime.UtcNow - startTime ;
   Console.WriteLine($"total time it takes : {totalTime}");
});
 
 app.UseWhen ( context => context.Request.Method != "GET",
                appBuilder => appBuilder.Use(async (context, next) =>
                {
                    var screatkey = context.Request.Headers["API-KEY"];
                    if(screatkey == "password")
                    {
                        await next.Invoke();
                    }
                    else
                    {
                        context.Response.StatusCode = 401;
                        await context.Response.WriteAsync("api key inccorext");
                    }
                })  

);

app.Use(async (context, next) =>
{   
    //before code
    Console.WriteLine(context.Request.Path);
      
    await next.Invoke();

    //after code 
    Console.WriteLine(context.Response.StatusCode);
});



app.UseAuthentication();
app.UseAuthorization();
app.UseHttpLogging();
app.MapControllers();

app.Run();