using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhaleEcommerce.Domain.Interfaces;
using WhaleEcommerce.Domain.Models;
using WhaleEcommerce.Infrastructure.Context;
using System.Linq;

namespace WhaleEcommerce.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(WhaleECommerceAppContext context) : base(context) { }

        public async Task<Product> GetProductCategory(Guid id)
        {
            return await Db.Products.AsNoTracking().Include(c => c.Category)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsCategories()
        {
            return await Db.Products.AsNoTracking().Include(c => c.Category)
                .OrderBy(b => b.Name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId)
        {
            return await Search(b => b.CategoryId == categoryId);
        }
    }
}