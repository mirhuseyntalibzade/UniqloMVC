using Microsoft.AspNetCore.Mvc;
using UniqloBL.Services.Abstractions;
using UniqloBL.Services.Concretes;
using UniqloDAL.Models;

namespace UniqloMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories = await _categoryService.GetAllCategoriesAsync();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(category);
            //}
            await _categoryService.CreateCategoryAsync(category);
            return RedirectToAction("Index","Categories");
        }

        public async Task<IActionResult> Update(int Id)
        {
            Category sliderItem = await _categoryService.GetCategoryByIdAsync(Id);
            if (sliderItem == null)
            {
                return NotFound("Something went wrong");
            }
            return View(sliderItem);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Category updatedCategoryItem)
        {
            Category currentItem = await _categoryService.GetCategoryByIdAsync(updatedCategoryItem.Id);
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest("Something went wrong");
            //}
            if (currentItem == null)
            {
                return NotFound("Something went wrong");
            }
            await _categoryService.EditCategoryAsync(updatedCategoryItem);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int Id)
        {
            Category deletedItem = await _categoryService.GetCategoryByIdAsync(Id);
            if (deletedItem == null)
            {
                return NotFound("Something went wrong");
            }
            await _categoryService.DeleteCategoryAsync(deletedItem);
            return RedirectToAction("Index","Categories");
        }
    }
}
