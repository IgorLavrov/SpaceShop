using Microsoft.AspNetCore.Mvc;
using SpaceShop.Models;
using System.Diagnostics;

namespace SpaceShop.Controllers
{
    public class PagesController : Controller
    {

        private readonly ILogger<PagesController> _logger;

        public PagesController(ILogger<PagesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      
    }
}
