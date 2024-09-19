using CatalogApi.Context;
using CatalogApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Controllers;

[Route("v1/api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly CADbContext _context;

    public ProductController(CADbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        var products = _context.Products.ToList();

        if (products is null)
        {
            return NotFound("Product not Found!");
        }

        return products;
    }
}
