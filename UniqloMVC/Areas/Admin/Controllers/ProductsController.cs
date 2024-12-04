using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniqloBL.Services.Abstractions;
using UniqloDAL.Contexts;
using UniqloDAL.Models;

namespace UniqloMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        readonly IProductService _productService;
        readonly ICategoryService _categoryService;
        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> categories = await _productService.GetAllProductsAsync();
            return View(categories);
        }
        public async Task<IActionResult> Create()
        {
            IEnumerable<Category> categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = new SelectList(categories,"Id","Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            await _productService.CreateProductAsync(category);
            return RedirectToAction("Index","Products");
        }

        public async Task<IActionResult> Update(int Id)
        {
            Product product = await _productService.GetProductByIdAsync(Id);
            if (product == null)
            {
                return NotFound("Something went wrong");
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product updatedProductItem)
        {
            Product currentItem = await _productService.GetProductByIdAsync(updatedProductItem.Id);
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            if (currentItem == null)
            {
                return NotFound("Something went wrong");
            }
            _productService.EditProductAsync(updatedProductItem);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int Id)
        {
            Product deletedItem = await _productService.GetProductByIdAsync(Id);
            if (deletedItem == null)
            {
                return NotFound("Something went wrong");
            }
            _productService.DeleteProductAsync(deletedItem);
            return RedirectToAction("Index");
        }
    }
}
