using UniqloDAL.Contexts;
using UniqloDAL.Models;
using Microsoft.AspNetCore.Mvc;
using UniqloBL.Services.Abstractions;

namespace Pronia_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderItemsController : Controller
    {
        readonly ISliderItemService _sliderItemService;

        public SliderItemsController(ISliderItemService sliderItemService)
        {
            _sliderItemService = sliderItemService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<SliderItem> sliderItems = await _sliderItemService.GetAllSliderItemsAsync();
            return View(sliderItems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SliderItem sliderItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            _sliderItemService.CreateSliderItem(sliderItem);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int Id)
        {
            SliderItem sliderItem =  await _sliderItemService.GetSliderItemAsync(Id);
            if (sliderItem == null)
            {
                return NotFound("Something went wrong");
            }
            return View(sliderItem);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SliderItem updatedSliderItem)
        {
            SliderItem currentItem = await _sliderItemService.GetSliderItemAsync(updatedSliderItem.Id);
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            if (currentItem == null)
            {
                return NotFound("Something went wrong");
            }
            _sliderItemService.UpdateSliderItem(updatedSliderItem);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int Id)
        {
            SliderItem deletedItem = await _sliderItemService.GetSliderItemAsync(Id);
            if (deletedItem == null)
            {
                return NotFound("Something went wrong");
            }
            _sliderItemService.DeleteSliderItem(deletedItem);
            return RedirectToAction("Index");
        }
    }
}
