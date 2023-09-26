using Ecommerce.BL;
using Ecommerce.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.APIs.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CategoryController : ControllerBase
{
    private readonly ICategoryManager manager;

    public CategoryController(ICategoryManager manager)
    {
        this.manager = manager;
    }
    [HttpGet]
    public ActionResult<List<CategoryWithProductReadDto>> GetAll()
    {
        return manager.GetAllCategoryWithProduct();
    }

    [HttpPost]
    public ActionResult Add(CategoryAddDto categoryAddDto)
    {
        manager.Add(categoryAddDto);
        return StatusCode(StatusCodes.Status201Created);

    }
}
