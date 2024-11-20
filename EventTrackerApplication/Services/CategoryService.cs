using EventTrackerCore.Abstractions;
using EventTrackerCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventTrackerApplication.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<List<Category>> GetAllCategoriesAsync()
        {
            return _categoryRepository.GetAllCategoriesAsync();
        }

        public Task<Category> GetCategoryByIdAsync(int id)
        {
            return _categoryRepository.GetCategoryByIdAsync(id);
        }

        public Task AddCategoryAsync(Category category)
        {
            return _categoryRepository.AddCategoryAsync(category);
        }

        public Task UpdateCategoryAsync(Category category)
        {
            return _categoryRepository.UpdateCategoryAsync(category);
        }

        public Task DeleteCategoryAsync(int id)
        {
            return _categoryRepository.DeleteCategoryAsync(id);
        }
    }
}
