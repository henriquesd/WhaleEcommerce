using System;
using System.Linq;
using System.Threading.Tasks;
using WhaleEcommerce.Domain.Interfaces;
using WhaleEcommerce.Domain.Models;

namespace WhaleEcommerce.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Add(Product product)
        {
            if (_productRepository.Search(b => b.Name == product.Name).Result.Any())
                return false;

            await _productRepository.Add(product);
            return true;
        }

        public async Task<bool> Update(Product product)
        {
            if (_productRepository.Search(b => b.Name == product.Name && b.Id != product.Id).Result.Any())
                return false;

            await _productRepository.Update(product);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            var product = await _productRepository.GetById(id);

            if (product == null) return false;

            await _productRepository.Remove(id);

            return true;
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
        }
    }
}
