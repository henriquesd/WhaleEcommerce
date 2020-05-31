using System;
using System.Threading.Tasks;
using WhaleEcommerce.Domain.Models;

namespace WhaleEcommerce.Domain.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        Task<bool> Add(Category category);
        Task<bool> Update(Category category);
        Task<bool> Remove(Guid id);
    }
}
