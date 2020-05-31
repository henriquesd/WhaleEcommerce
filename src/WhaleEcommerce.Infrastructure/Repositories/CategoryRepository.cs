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
      
    }
}