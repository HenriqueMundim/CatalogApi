using CatalogApi.Domain.Entities;
using CatalogApi.Domain.Errors;
using CatalogApi.Domain.Interfaces;

namespace CatalogApi.Domain.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Task<Category> FindById(int id)
        {
            var category = _repository.FindById(id);

            if (category is null)
                throw new ArgumentException("Not found!");

            return category;
        }

        public Task<IEnumerable<Category>> GetAll()
        {
            var categories = _repository.GetAll();

            if (categories is null)
                throw new ArgumentException("Not found");

            return categories;
        }

        public async Task<Category> Create(Category category)
        {
            if (category is null)
                throw new ArgumentException("Category is null");

            var newCartegory = await _repository.Create(category);

            return newCartegory;
        }

        public async Task Update(int id, Category category)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Bad aguments");
            }

            if (category is null)
                throw new ArgumentException("Bad arguments");

            var isExist = await _repository.FindById(id);

            if (isExist is null)
                throw new ArgumentException("Category not found");

            await _repository.Update(category);
        }

        public async Task Delete(int id)
        {
            var isExists = await _repository.FindById(id);

            if (isExists is null)
                throw new NotFoundException("Category not found");

            await _repository.Delete(isExists);
        }
    }
}
