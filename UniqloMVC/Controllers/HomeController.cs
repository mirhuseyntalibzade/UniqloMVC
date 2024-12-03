using Microsoft.AspNetCore.Mvc;
using UniqloBL.Services.Abstractions;
using UniqloDAL.Models;

namespace UniqloMVC.Controllers
{
    public class HomeController : Controller
    {
        readonly ISliderItemService _sliderItemService;

        public HomeController(ISliderItemService sliderItemService)
        {
            _sliderItemService = sliderItemService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<SliderItem> sliderItems= await _sliderItemService.GetAllSliderItemsAsync();
            return View(sliderItems);
        }
    }
}
