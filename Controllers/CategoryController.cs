using CatalogApi.Context;
using CatalogApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    public ActionResult<IEnumerable<Category>> Get()
    {
        var categories = _context.Categories.ToList();

        return categories;
    }

}

