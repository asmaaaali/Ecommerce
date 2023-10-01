namespace Ecommerce.DTOs;

public record ProductUpdateDto(string Name, decimal Price, int Quantity, int CategoryId, int ProductId);
