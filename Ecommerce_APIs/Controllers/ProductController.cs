using Ecommerce.BL;
using Ecommerce.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.APIs;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductManager manager;

    public ProductController(IProductManager manager)
    {
        this.manager = manager;
    }
    [HttpGet]
    [Route("Category/{categoryId}")]
    public ActionResult<List<ProductReadDto>> GetProductsByCategory(int categoryId)
    {
        return manager.GetProductsByCategoryId(categoryId);
    }

    [HttpPost]
    public ActionResult Add(ProductAddDto product)
    {
         manager.Add(product);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut]
    public ActionResult Update(ProductUpdateDto product)
    {
        manager.Update(product);
        return NoContent();
    }
    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int id)
    {
        manager.Delete(id);
        return NoContent();
    }
}
