using Microsoft.AspNetCore.Mvc;

namespace SpaceShop.Controllers
{
    public class Spaceships : Controller
    {
       

            public IActionResult Index()
            {
                return View();
            }
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

        
    }
}
