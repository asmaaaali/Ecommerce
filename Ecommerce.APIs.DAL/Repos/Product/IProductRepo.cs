namespace Ecommerce.DAL;

public interface IProductRepo
{
    List<Product> GetAllByCategoryId(int categoryId);
     void Add(Product product);
    int SaveChanges();
    void Updates(Product product);
    Product? GetById(int id);
    void Delete(Product product);
}

