using Microsoft.AspNetCore.Mvc;
using UniqloBL.Services.Abstractions;
using UniqloDAL.Models;

namespace UniqloMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories = await _service.GetAllCategoriesAsync();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            return View(category);
        }
    }
}
