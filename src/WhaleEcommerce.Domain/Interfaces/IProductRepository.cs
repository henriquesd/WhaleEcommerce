using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhaleEcommerce.Domain.Models;

namespace WhaleEcommerce.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId);
        Task<IEnumerable<Product>> GetProductsCategories();
        Task<Product> GetProductCategory(Guid id);
    }
}
