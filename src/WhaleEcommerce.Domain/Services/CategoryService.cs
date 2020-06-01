using System;
using System.Linq;
using System.Threading.Tasks;
using WhaleEcommerce.Domain.Interfaces;
using WhaleEcommerce.Domain.Models;
using WhaleEcommerce.Domain.Models.Validations;

namespace WhaleEcommerce.Domain.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository,
                                INotifyer notifyer) : base(notifyer)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Add(Category category)
        {
            if (!ExecuteValidation(new CategoryValidation(), category)) return false;

            if (_categoryRepository.Search(c => c.Description == category.Description).Result.Any())
            {
                Notify("A Category with this description already exists.");
                return false;
            }

            await _categoryRepository.Add(category);
            return true;
        }

        public async Task<bool> Update(Category category)
        {
            if (!ExecuteValidation(new CategoryValidation(), category)) return false;

            if (_categoryRepository.Search(c => c.Description == category.Description && c.Id != category.Id).Result.Any())
            {
                Notify("A Category with this description already exists.");
                return false;
            }

            await _categoryRepository.Update(category);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            if (_categoryRepository.GetCategoryProducts(id).Result.Products.Any())
            {
                Notify("There is registered product(s) for this category!");
                return false;
            }

            await _categoryRepository.Remove(id);
            
            return true;
        }

        public void Dispose()
        {
            _categoryRepository?.Dispose();
        }
    }
}
