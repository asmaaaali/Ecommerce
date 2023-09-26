using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DAL;

public class CategoryRepo : ICategoryRepo
{
    private readonly EcommerecContext context;

    public CategoryRepo(EcommerecContext context)
    {
        this.context = context;
    }

    public void Add(Category category)
    {
       context.Add(category);
    }

    public List<Category> GetCategoriesWithProducts()
    {
        return context.Categories.Include(c => c.Products).ToList();
    }

    public int SaveChanges()
    {
        return context.SaveChanges();
    }
}
