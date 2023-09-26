using Ecommerce.DAL;
using Ecommerce.DTOs;

namespace Ecommerce.BL;

public class ProductManager : IProductManager
{
    private readonly IProductRepo repo;

    public ProductManager(IProductRepo repo)
    {
        this.repo = repo;
    }

    public void Add(ProductAddDto product)
    {
        var DbProduct = new Product
        {
            Name = product.Name,
            CategoryId = product.CategoryId,
            Price = product.Price,
            Quantity = product.Quantity,
        };
        repo.Add(DbProduct);
       repo.SaveChanges();
    }

    public List<ProductReadDto> GetProductsByCategoryId(int id)
    {
       var DbProducts = repo.GetAllByCategoryId(id);
      return  DbProducts.Select(p => new ProductReadDto(p.Id, p.Name, p.Category!.Name, p.Quantity > 0)).ToList();
        
    }
}
