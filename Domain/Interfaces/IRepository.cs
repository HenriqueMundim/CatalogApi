namespace CatalogApi.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> FindById(int id);
        Task<T> Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
