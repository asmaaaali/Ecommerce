
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DAL;

public class EcommerecContext : DbContext
{

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    public EcommerecContext(DbContextOptions<EcommerecContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasData(
              new List<Product>
 {
    new Product { Id = 1, Name = "Smartphone", Price = 599.99m, Quantity = 100, CategoryId = 1},
    new Product { Id = 2, Name = "Laptop", Price = 999.99m, Quantity = 50, CategoryId = 1 },
    new Product { Id = 3, Name = "T-Shirt", Price = 19.99m, Quantity = 200, CategoryId = 2},
    new Product { Id = 4, Name = "Washing Machine", Price = 449.99m, Quantity = 30, CategoryId = 3},
    new Product { Id = 5, Name = "Headphones", Price = 89.99m, Quantity = 150, CategoryId = 1 },
    new Product { Id = 6, Name = "Jeans", Price = 39.99m, Quantity = 120, CategoryId = 2 },
    new Product { Id = 7, Name = "Refrigerator", Price = 799.99m, Quantity = 40, CategoryId = 3 },
    new Product { Id = 8, Name = "Tablet", Price = 299.99m, Quantity = 75, CategoryId = 1 },
 });
        modelBuilder.Entity<Category>().HasData(
              new List<Category>()
  {
    new Category { Id = 1, Name = "Electronics" },
    new Category { Id = 2, Name = "Clothing" },
    new Category { Id = 3, Name = "Home Appliances" }


              }  ) ;

    }

}
