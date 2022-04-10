using Microsoft.AspNetCore.Mvc;
using ProTechniqueInfrastructure.Business.Abstract;
using ProTechniqueInfrastructure.Entities.Concrete;

namespace ProTechniqueInfrastructure.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        var result = await _categoryService.GetAllAsync();
        return result.Success
            ? Ok(result.Data)
            : BadRequest(result.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int CategoryId)
    {
        var result = await _categoryService.GetByIdAsync(CategoryId);
        return result.Success
            ? Ok(result.Data)
            : BadRequest(result.Message);
    }

    [HttpPost()]
    public async Task<IActionResult> Add([FromBody] Category category)
    {
        var result = await _categoryService.AddAsync(category);
        return result.Success
            ? StatusCode(StatusCodes.Status201Created, result.Message)
            : BadRequest(result.Message);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int productId)
    {
        var entity = (await _categoryService.GetByIdAsync(productId)).Data;
        await _categoryService.Delete(entity);
        return NoContent();
    }
}