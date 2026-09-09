var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("users/{userid}/blogs/{blogTitle}", (int userid, string blogTitle ) =>
{
    return $"user is : {userid} has blog title : {blogTitle}";
});


app.MapGet("productId/{id:int:min(0)}", (int id) =>
{
    return $"product id is : {id}";
});

app.MapGet("username/{name?}", (string? name) =>
{
    return $"user name is {name}";
});

app.MapGet("filename/{*file}", (string file) =>
{
    return $"you file is save at {file}";
});

app.MapGet("search/", (string? q,int page=1) =>
{
    return $"search for {q} on page {page}";
});



app.Run();
