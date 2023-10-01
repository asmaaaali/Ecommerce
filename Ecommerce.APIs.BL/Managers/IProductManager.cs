using Ecommerce.DTOs;

namespace Ecommerce.BL;

public interface IProductManager
{
    List<ProductReadDto> GetProductsByCategoryId(int id);
    void Add(ProductAddDto product);
    void Update(ProductUpdateDto product);
    void Delete(int id);
    
}
