using CatalogApi.Domain.Entities;

namespace CatalogApi.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<IEnumerable<Category>> GetAllWithProducts();
        Task<Category> FindById(int id);
        Task<Category> Create(Category category);
        Task Update(Category category);
        Task Delete(Category category);
    }
}
