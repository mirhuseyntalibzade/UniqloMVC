using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UniqloBL.Services.Abstractions;
using UniqloDAL.Contexts;
using UniqloDAL.Models;

namespace UniqloBL.Services.Concretes
{

    public class CategoryService : ICategoryService
    {
        readonly UniqloDbContext _context;

        public CategoryService(UniqloDbContext context)
        {
            _context = context;
        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task EditCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            IEnumerable<Category> categories = await _context.Categories.ToListAsync();
            return (categories);
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            Category? category = await _context.Categories.FirstOrDefaultAsync();
            return (category);
        }
    }
}
