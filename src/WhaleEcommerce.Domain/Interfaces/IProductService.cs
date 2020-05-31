using System;
using System.Threading.Tasks;
using WhaleEcommerce.Domain.Models;

namespace WhaleEcommerce.Domain.Interfaces
{
    public interface IProductService
    {
        Task<bool> Add(Product product);
        Task<bool> Update(Product product);
        Task<bool> Remove(Guid id);
    }
}
