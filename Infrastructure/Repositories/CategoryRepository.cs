using CatalogApi.Domain.Entities;
using CatalogApi.Domain.Interfaces;
using CatalogApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogApi.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(CADbContext _dbContext) : base(_dbContext) { }
    }
}
