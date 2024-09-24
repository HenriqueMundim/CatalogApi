using CatalogApi.Domain.Entities;
using CatalogApi.Domain.Interfaces;
using CatalogApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogApi.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CADbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetAllWithCategory()
        {
            return await this._context.Products.Include(p => p.Category).ToListAsync();
        }
    }
}
