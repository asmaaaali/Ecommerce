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

    public void Delete(int id)
    {
       var prodToDelete= repo.GetById(id);
        if (prodToDelete is null)
        {
            return;
        }
        repo.Delete(prodToDelete);
        repo.SaveChanges();
    }

    public List<ProductReadDto> GetProductsByCategoryId(int id)
    {
       var DbProducts = repo.GetAllByCategoryId(id);
      return  DbProducts.Select(p => new ProductReadDto(p.Id, p.Name, p.Category!.Name, p.Quantity > 0)).ToList();
        
    }

    public void Update(ProductUpdateDto productFromUser)
    {
        var dbProduct = repo.GetById(productFromUser.ProductId);
        if (dbProduct is null)
        {
            return;
        }
        dbProduct.Name=productFromUser.Name;
        dbProduct.Price=productFromUser.Price;
        dbProduct.Quantity=productFromUser.Quantity;
        dbProduct.CategoryId=productFromUser.CategoryId;
        repo.Updates(dbProduct);
        repo.SaveChanges();
    }
}
