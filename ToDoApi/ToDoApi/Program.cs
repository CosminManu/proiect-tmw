using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SqliteConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'SqliteConnection' is not defined.");
}

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(connectionString));


var app = builder.Build();


//app.UseHttpsRedirection(); 
//if you hit 'http' endpoint it automatically sends you to 'https'; good to use http for android endpoints
//https can be used in dev environment, just a bit extra work to configure


app.MapGet("api/todos", async (AppDbContext ctx) =>
{
    var items = await ctx.toDos.ToListAsync();

    return Results.Ok(items);
});

app.MapPost("api/createToDo", async (AppDbContext ctx, ToDo toDo) =>
{
    await ctx.toDos.AddAsync(toDo);

    await ctx.SaveChangesAsync();

    return Results.Created($"api/createToDo/{toDo.Id}", toDo);
});

app.MapPut("api/todos/{id}", async (AppDbContext ctx, int id, ToDo todo) =>
{
    var toDoModel = await ctx.toDos.FirstOrDefaultAsync(t => t.Id == id);

    if(toDoModel == null)
    {
        return Results.NotFound();
    }

    toDoModel.ToDoName = todo.ToDoName;

    await ctx.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("api/todos/{id}", async (AppDbContext ctx, int id) =>
{
    var toDoModel = await ctx.toDos.FirstOrDefaultAsync(t => t.Id == id);

    if (toDoModel == null)
    {
        return Results.NotFound();
    }

    ctx.toDos.Remove(toDoModel);

    await ctx.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();
