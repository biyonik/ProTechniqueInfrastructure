using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProTechniqueInfrastructure.Business.Abstract;
using ProTechniqueInfrastructure.Entities.Concrete;

namespace ProTechniqueInfrastructure.WebAPI.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet()]
    [Authorize("Product.List")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _productService.GetAllAsync();
        return result.Success
            ? Ok(result.Data)
            : BadRequest(result.Message);
    }

    [HttpGet("[action]/{categoryId}")]
    public async Task<IActionResult> GetByCategoryId(int categoryId)
    {
        var result = await _productService.GetListByCategory(categoryId);
        return result.Success
            ? Ok(result.Data)
            : BadRequest(result.Message);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _productService.GetByIdAsync(id);
        return result.Success
            ? Ok(result.Data)
            : BadRequest(result.Message);
    }

    [HttpPost()]
    public async Task<IActionResult> Add([FromBody] Product entity)
    {
        var result = await _productService.AddAsync(entity);
        return result.Success
            ? StatusCode(StatusCodes.Status201Created, result.Message)
            : BadRequest(result.Message);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int productId, Product newEntity)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int productId)
    {
        var entity = (await _productService.GetByIdAsync(productId)).Data;
        if (entity != null)
        {
            await _productService.Delete(entity);
            return NoContent();
        }
        else
        {
            return BadRequest();
        }
    }
}