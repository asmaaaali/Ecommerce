
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DAL;

public class EcommerecContext : DbContext
{

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    public EcommerecContext(DbContextOptions<EcommerecContext> options) : base(options)
    {

    }

}
