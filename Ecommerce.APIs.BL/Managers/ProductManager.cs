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
    public List<ProductReadDto> products(int id)
    {
       var DbProducts = repo.GetAllByCategoryId(id);
      return  DbProducts.Select(p => new ProductReadDto(p.Id, p.Name, p.Category!.Name, p.Quantity > 0)).ToList();
        
    }
}
