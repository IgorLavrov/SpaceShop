using Microsoft.AspNetCore.Mvc;

namespace SpaceShop.Controllers
{
    public class SpaceshipsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] public IActionResult Create()
        {
            return View();
        
        }

    }
}
