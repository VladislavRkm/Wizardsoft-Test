using EventTrackerCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventTrackerCore.Abstractions;

public interface ICategoryService
{
    Task<List<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);
    Task AddCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(int id);
}
