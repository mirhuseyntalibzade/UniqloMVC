using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqloDAL.Models;

namespace UniqloBL.Services.Abstractions
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllCategoriesAsync();
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task EditCategoryAsync(Category category);
        public Task DeleteCategoryAsync(Category category);
    }
}
