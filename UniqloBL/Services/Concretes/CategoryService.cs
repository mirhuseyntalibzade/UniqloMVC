using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqloBL.Services.Abstractions;
using UniqloDAL.Contexts;
using UniqloDAL.Models;

namespace UniqloBL.Services.Concretes
{

    public class CategoryService : ICategoryService
    {
        readonly UniqloDBContext _context;

        public CategoryService(UniqloDBContext context)
        {
            _context = context;
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
