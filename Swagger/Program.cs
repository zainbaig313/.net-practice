using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Swashbuckle.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var books =  new List<Item>{
        new Item {Id = 1 , Title = "book1"},
        new Item {Id = 22 , Title = "book2"}
    };


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/getAllBook" , () =>
{
    return Results.Ok(books);
});


app.MapGet("/getBookById/{id}" ,Results<Ok<Item>, NotFound> (int id) =>
{   
    var item = books.FirstOrDefault(i=> i.Id==id);
    if(item == null)
    {
        return TypedResults.NotFound();
    }
    return TypedResults.Ok(item);
}).WithOpenApi(operation =>
{
    operation.Parameters[0].Description = "this is the id of the book";
    operation.Summary = "Get single Blog";
    operation.Description = " return a single blog";
    return operation;
});


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


