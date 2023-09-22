using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DAL;

public class ProductRepo : IProductRepo
{
    private readonly EcommerecContext context;

    public ProductRepo(EcommerecContext context)
    {
        this.context = context;
    }
    public List<Product> GetAllByCategoryId(int categoryId)
    {
       return context.Set<Product>().Where(p => p.CategoryId == categoryId).Include(p=>p.Category).ToList();
    }
}
