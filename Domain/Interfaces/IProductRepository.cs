using CatalogApi.Domain.Entities;

namespace CatalogApi.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllWithCategory();
    }
}

