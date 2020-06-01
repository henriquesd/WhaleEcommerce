using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhaleEcommerce.Domain.Interfaces;
using WhaleEcommerce.Domain.Models;
using WhaleEcommerce.Infrastructure.Context;

namespace WhaleEcommerce.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(WhaleECommerceAppContext context) : base(context) { }

        public async Task<Category> GetCategoryProducts(Guid id)
        {
            return await Db.Categories.AsNoTracking()
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}