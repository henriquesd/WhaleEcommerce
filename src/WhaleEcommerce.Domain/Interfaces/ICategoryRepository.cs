using System;
using System.Threading.Tasks;
using WhaleEcommerce.Domain.Models;

namespace WhaleEcommerce.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCategoryProducts(Guid id);
    }
}
