using CatalogApi.Domain.Entities;
using CatalogApi.Domain.Interfaces;
using CatalogApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogApi.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CADbContext _dbContext;
        public CategoryRepository(CADbContext context)
        {
            _dbContext = context;
        }

        public async Task<Category> FindById(int id)
        {
            var category = await _dbContext.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            return category;
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = await _dbContext.Categories.AsNoTracking().ToListAsync();

            return categories;
        }

        public async Task<IEnumerable<Category>> GetAllWithProducts()
        {
            var categories = await _dbContext.Categories.Include(p => p.Products).AsNoTracking().ToListAsync();

            return categories;
        }
        public async Task<Category> Create(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return category;
        }
        public async Task Update(Category category)
        {
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(Category category)
        {
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
