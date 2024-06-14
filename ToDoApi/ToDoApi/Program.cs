using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;

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



app.Run();
