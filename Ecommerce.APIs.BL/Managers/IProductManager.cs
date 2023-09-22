using Ecommerce.DTOs;

namespace Ecommerce.BL;

public interface IProductManager
{
    List<ProductReadDto> products(int id);
}
