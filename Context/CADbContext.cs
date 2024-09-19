using CatalogApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogApi.Context
{
    public class CADbContext : DbContext
    {
        public CADbContext(DbContextOptions<CADbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
