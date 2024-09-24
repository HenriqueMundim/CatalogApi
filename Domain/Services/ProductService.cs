using CatalogApi.Domain.Entities;
using CatalogApi.Domain.Errors;
using CatalogApi.Domain.Interfaces;

namespace CatalogApi.Domain.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid ID");

            var product = await _repository.FindById(id);

            if (product is null)
                throw new NotFoundException("Product not found!");

            return product;
        }

        public async Task<IEnumerable<Product>> GetAllWithCategory()
        {
            var products = await _repository.GetAllWithCategory();

            if (products is null)
                throw new NotFoundException("Products not found!");

            return products;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _repository.GetAll();

            if (products is null)
                throw new NotFoundException("Products not found!");

            return products;
        }

        public async Task<Product> Create(Product product)
        {
            if (product is null)
                throw new ArgumentException("Invalida product");

            var newProduct = await _repository.Create(product);

            return newProduct;
        }

        public async Task Update(int id, Product product)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Bad aguments");
            }

            if (product is null)
                throw new ArgumentException("Bad arguments");

            var isExist = await _repository.FindById(id);

            if (isExist is null)
                throw new ArgumentException("Category not found");

            await _repository.Update(product);
        }

        public async Task Delete(int id)
        {
            var product = await _repository.FindById(id);

            if (product is null)
                throw new NotFoundException("Product not found");

            await _repository.Delete(product);
        }

    }
}
