using Ecommerce.DAL;
using Ecommerce.DTOs;

namespace Ecommerce.BL;

public class CategoryManager : ICategoryManager
{
    private readonly ICategoryRepo repo;

    public CategoryManager(ICategoryRepo repo)
    {
        this.repo = repo;
    }
    public List<CategoryWithProductReadDto> GetAllCategoryWithProduct()
    {
       var CategoryDb= repo.GetCategoriesWithProducts();


        return CategoryDb.Select(c => new CategoryWithProductReadDto(c.Id,
            c.Name,
            c.Products.Select(p => new ProductChildDto(p.Id, p.Name)).ToList()
            )).ToList();
    }
}
