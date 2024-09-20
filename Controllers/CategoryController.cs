using CatalogApi.Context;
using CatalogApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogApi.Controllers;

[Route("v1/api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly CADbContext _context;

    public CategoryController(CADbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async  Task<ActionResult<IEnumerable<Category>>> Get()
    {
        var categories = await _context.Categories.AsNoTracking().ToListAsync();
        
        return categories;
    }

    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesProducts()
    {
        var categories = await _context.Categories.Include(p => p.Products).AsNoTracking().ToListAsync();

        return categories;
    }

    [HttpGet("{id:int}", Name = "GetCategory")]
    public async Task<ActionResult<Category>> GetById(int id)
    {
        var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        if (category is null)
            return NotFound("Category not found!");

        return category;
    }

    [HttpPost]
    public ActionResult<Category> Post(Category category)
    {
        if (category is null)
            return BadRequest();

        _context.Categories.Add(category);
        _context.SaveChanges();

        return new CreatedAtRouteResult("GetCategory",
            new { id = category.Id }, category);
    }


    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Category category)
    {
        if (category.Id != id)
            return BadRequest();

        _context.Entry(category).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var category = _context.Categories.Find(id);

        if (category is null)
            return NotFound("Category not found!");

        _context.Categories.Remove(category);
        _context.SaveChanges();

        return NoContent();
    }
}

