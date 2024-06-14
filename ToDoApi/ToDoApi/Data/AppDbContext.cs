using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //DbSet : representation of todo items into the database
        public DbSet<ToDo> toDos => Set<ToDo>();
    }
}
