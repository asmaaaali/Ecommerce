using Ecommerce.DTOs;

namespace Ecommerce.BL;

public interface ICategoryManager
{
    List<CategoryWithProductReadDto> GetAllCategoryWithProduct();
    void Add(CategoryAddDto categoryAddDto);
}
