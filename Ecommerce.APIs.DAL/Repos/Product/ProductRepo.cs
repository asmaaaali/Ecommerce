using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DAL;

public class ProductRepo : IProductRepo
{
    private readonly EcommerecContext context;

    public ProductRepo(EcommerecContext context)
    {
        this.context = context;
    }

    public void Add(Product product)
    {
        context.Set<Product>().Add(product);
    }

    public void Delete(Product product)
    {
        context.Set<Product>().Remove(product);
    }

    public List<Product> GetAllByCategoryId(int categoryId)
    {
       return context.Set<Product>().Where(p => p.CategoryId == categoryId).Include(p=>p.Category).ToList();
    }

    public Product? GetById(int id)
    {
       return  context.Set<Product>().Find(id);
    }

    public int SaveChanges()
    {
        return context.SaveChanges();
    }

    public void Updates(Product product)
    {
        
    }
}
