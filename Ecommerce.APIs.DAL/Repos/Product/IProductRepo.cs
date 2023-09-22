namespace Ecommerce.DAL;

public interface IProductRepo
{
    List<Product> GetAllByCategoryId(int categoryId);
}
