using CatalogApi.Context;
using CatalogApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        var products = _context.Products.AsNoTracking().ToList();

        if (products is null)
        {
            return NotFound("Product not Found!");
        }

        return products;
    }

    [HttpGet("{id:int}", Name = "GetProduct")]
    public ActionResult<Product> GetById([FromRoute] int id)
    {
        var product = _context.Products.AsNoTracking().SingleOrDefault(p => p.Id == id);

        if (product == null)
        {
            return NotFound("Product not found!");
        }

        return product;
    }

    [HttpPost]
    public ActionResult Post(Product product)
    {
        if (product is null)
            return BadRequest();

        _context.Products.Add(product);
        _context.SaveChanges();

        return new CreatedAtRouteResult("GetProduct", new { id = product.Id }, product);

    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Product product)
    {
        if (id != product.Id)
            return BadRequest();

        _context.Entry(product).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var product = _context.Products.SingleOrDefault(p => p.Id == id);

        if (product is null)
            return BadRequest();

        _context.Products.Remove(product);
        _context.SaveChanges();

        return NoContent();

    }
}
