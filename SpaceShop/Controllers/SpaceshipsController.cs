using Microsoft.AspNetCore.Mvc;
using Shop.Core.ServiceInterface;
using Shop.Data;

namespace SpaceShop.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly ShopContext _context;
        private readonly ISpaceshipServices _spaceshipServices;
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
