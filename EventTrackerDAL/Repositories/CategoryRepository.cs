
using EventTrackerCore.Abstractions;
using EventTrackerCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventTrackerDAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EventTrackerContext _context;

        public CategoryRepository(EventTrackerContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.Include(c => c.Children).ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.Include(c => c.Children).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.Include(c => c.Children).FirstOrDefaultAsync(c => c.Id == id);
            if (category != null)
            {
                foreach (var child in category.Children)
                {
                    child.ParentId = null;
                }
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

    }
}
