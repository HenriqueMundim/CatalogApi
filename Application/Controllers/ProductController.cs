using CatalogApi.Domain.Entities;
using CatalogApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Application.Controllers;

[Route("v1/api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
        var products = await _service.GetAll();
        return Ok(products);
    }

    [HttpGet("category")]
    public async Task<ActionResult<IEnumerable<Product>>> GetWIthCategory()
    {
        var products = await _service.GetAllWithCategory();
        return Ok(products);
    }

    [HttpGet("{id:int}", Name = "GetProduct")]
    public async Task<ActionResult<Product>> GetById([FromRoute] int id)
    {
        var product = await _service.GetById(id);

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> Post(Product product)
    {
        var newProduct = await _service.Create(product);

        return new CreatedAtRouteResult("GetProduct", new { id = newProduct.Id }, newProduct);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, Product product)
    {
        await _service.Update(id, product);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
       await _service.Delete(id);

       return NoContent();
    }
}
