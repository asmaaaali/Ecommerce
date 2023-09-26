namespace Ecommerce.DAL;

public interface ICategoryRepo
{
    List<Category> GetCategoriesWithProducts();
}
