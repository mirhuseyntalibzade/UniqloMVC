using Microsoft.AspNetCore.Mvc;

namespace UniqloMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
