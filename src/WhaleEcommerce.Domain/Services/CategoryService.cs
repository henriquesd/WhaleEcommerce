using System;
using System.Linq;
using System.Threading.Tasks;
using WhaleEcommerce.Domain.Interfaces;
using WhaleEcommerce.Domain.Models;

namespace WhaleEcommerce.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Add(Category category)
        {
            if (_categoryRepository.Search(c => c.Description == category.Description).Result.Any())
                return false;

            await _categoryRepository.Add(category);
            return true;
        }

        public async Task<bool> Update(Category category)
        {
            if (_categoryRepository.Search(c => c.Description == category.Description && c.Id != category.Id).Result.Any())
                return false;

            await _categoryRepository.Update(category);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            if (_categoryRepository.GetCategoryProduct(id).Result.Products.Any()) return false;

            var category = await _categoryRepository.GetById(id);

            if (category == null) return false;
             
            await _categoryRepository.Remove(id);
                return true;
        }

        public void Dispose()
        {
            _categoryRepository?.Dispose();
        }
    }
}
