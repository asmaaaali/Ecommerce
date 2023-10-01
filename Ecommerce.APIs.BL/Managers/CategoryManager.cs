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

    public void Add(CategoryAddDto categoryAddDto)
    {
       var dbCategory = new Category
        {
            Name = categoryAddDto.Name,
        };
         repo.Add(dbCategory);
         repo.SaveChanges();
    }

    public void Delete(int id)
    {
       var CatToDelete=repo.GetById(id);
        if (CatToDelete is null)
        {
            return;
        }
        repo.Delete(CatToDelete);
    }

    public List<CategoryWithProductReadDto> GetAllCategoryWithProduct()
    {
       var CategoryDb= repo.GetCategoriesWithProducts();


        return CategoryDb.Select(c => new CategoryWithProductReadDto(c.Id,
            c.Name,
            c.Products.Select(p => new ProductChildDto(p.Id, p.Name)).ToList()
            )).ToList();
    }

    public void Update(CategoryUpdateDto categoryUpdateDto)
    {
        var dbCategory = repo.GetById(categoryUpdateDto.CategoryId);
        if (dbCategory is null)
        {
            return;
        }
        dbCategory.Name= categoryUpdateDto.Name;
        repo.Update(dbCategory);
        repo.SaveChanges();
    }

}
