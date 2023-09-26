namespace Ecommerce.DAL;

public interface ICategoryRepo
{
    List<Category> GetCategoriesWithProducts();
    void Add(Category category);
    int SaveChanges();
}
