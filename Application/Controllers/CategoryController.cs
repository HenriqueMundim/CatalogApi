using CatalogApi.Domain.Entities;
using CatalogApi.Domain.Services;
using CatalogApi.Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Application.Controllers;

[Route("v1/api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _service;

    public CategoryController(CategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    [ServiceFilter(typeof(ApiLoggingFilter))]
    public async Task<ActionResult<IEnumerable<Category>>> GetAll()
    {
        var categories = await _service.GetAll();

        return Ok(categories);
    }

    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesProducts()
    {
        var categories = await _service.GetAllWithProducts();

        return Ok(categories);
        
    }

    [HttpGet("{id:int}", Name = "GetCategory")]
    public async Task<ActionResult<Category>> GetById(int id)
    {
        var category = await _service.FindById(id);

        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<Category>> Post(Category category)
    {
        var newCategory = await _service.Create(category);

        return new CreatedAtRouteResult("Getcategory", new { id = newCategory.Id }, newCategory);
    }


    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, Category category)
    {
        await _service.Update(id, category);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.Delete(id);

        return NoContent();
    }
}

