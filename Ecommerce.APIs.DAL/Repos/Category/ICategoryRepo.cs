namespace Ecommerce.DAL;

public interface ICategoryRepo
{
    List<Category> GetCategoriesWithProducts();
    void Add(Category category);
    int SaveChanges();
    void Update(Category category);
        Category? GetById(int id);
    void Delete(Category category);
}
