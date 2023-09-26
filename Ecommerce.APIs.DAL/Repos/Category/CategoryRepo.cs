using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DAL;

public class CategoryRepo : ICategoryRepo
{
    private readonly EcommerecContext context;

    public CategoryRepo(EcommerecContext context)
    {
        this.context = context;
    }
    public List<Category> GetCategoriesWithProducts()
    {
        return context.Categories.Include(c => c.Products).ToList();
    }
}
