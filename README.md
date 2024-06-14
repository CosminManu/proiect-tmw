# .NET MAUI (multi platform application user interface) project

Command line 
- `dotnet --version` to see the current version of .net installed (ex 8.0.200)
- `dotnet run` builds & runs app from root project
- `dotnet watch` builds, runs & hotreload enabled -> every change to app, every new line will automatically update (no more stop&run to see the change)



Recap on Migrations
- Add a Migration: `dotnet ef migrations add InitialMigration`
This creates a migration class to update your database schema based on your current model.

- Apply the Migration: `dotnet ef database update`
This applies any pending migrations to your database, creating or modifying the necessary tables and columns.

Create Subsequent Migrations:
- Whenever you make changes to your model (like adding a new entity or modifying an existing one), you can create a new migration to reflect those changes: `dotnet ef migrations add AddNewEntity`

And then apply it:
`dotnet ef database update`

**Best Practices**
_Version Control_: Always check your migration files into version control. This ensures that your team can keep the database schema in sync across different environments.
_Review Migrations_: Before applying a migration, review the generated code to ensure it accurately reflects your intended changes.
_Use Seed Data_: If you need to insert initial data into your database, consider using the OnModelCreating method in your DbContext or creating a dedicated migration for seeding data.

Example: Adding a New Entity
Suppose you want to add a Product entity to your application:

Define the Entity:
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
Update DbContext:
public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; } // Add this line

    // Rest of your DbContext configuration
}

Add a Migration: `dotnet ef migrations add AddProductEntity`
Apply the Migration: `dotnet ef database update`

This will create the Products table in your database with the specified columns.