using System;
using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
            new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
            new Category { Id = 3, Name = "History", DisplayOrder = 3 }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Author = "John Doe",
                Title = "Running Free",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed iaculis leo id porttitor feugiat. Aenean efficitur sodales libero, a placerat velit commodo ut.",
                ISBN = "AA15845467881101",
                ListPrice = 99,
                Price = 90,
                Price50 = 85,
                Price100 = 80
            },
            new Product
            {
                Id = 2,
                Author = "Max Mustermann",
                Title = "How to become an incognito",
                Description = "Proin imperdiet lectus vel sem sodales, sed tincidunt arcu blandit. Mauris commodo sapien ex, vitae facilisis nisi convallis ac. Vestibulum tellus turpis, pulvinar vel pulvinar sed, imperdiet eu libero.",
                ISBN = "BB12312313312303",
                ListPrice = 40,
                Price = 30,
                Price50 = 25,
                Price100 = 20
            },
            new Product
            {
                Id = 3,
                Author = "João da Silva",
                Title = "Por que era só mais um Silva",
                Description = "Maecenas venenatis sit amet nunc at hendrerit. Nulla eget arcu molestie, placerat odio et, scelerisque odio. Nam vestibulum eget nunc sollicitudin vulputate.",
                ISBN = "CC4182438124315245",
                ListPrice = 55,
                Price = 50,
                Price50 = 45,
                Price100 = 40
            }
        );
    }
}
