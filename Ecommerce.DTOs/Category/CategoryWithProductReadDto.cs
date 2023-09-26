namespace Ecommerce.DTOs;

public record CategoryWithProductReadDto(int Id , string Name, List<ProductChildDto>Products);
