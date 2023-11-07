using Microsoft.AspNetCore.Mvc;
using Shop.Core.ServiceInterface;

namespace SpaceShop.Controllers
{
    public class OpenWeatherController : Controller
    {
        private readonly IWeatherForecastServices _weatherForecastServices;

        public OpenWeatherController (IWeatherForecastServices weatherForecastServices)
       {
            _weatherForecastServices = weatherForecastServices;

         }

        public IActionResult Index()
        {
            return View();

        }


    }
}
