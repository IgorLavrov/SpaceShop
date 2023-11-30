using Microsoft.AspNetCore.Mvc;
using Shop.ApplicationServices.Services;
using Shop.Core.Dto.Accuweather;
using Shop.Core.Dto.OpenWeatherDto;
using Shop.Core.ServiceInterface;
using SpaceShop.Models.AccuWeather;
using SpaceShop.Models.OpenWeathers;

namespace SpaceShop.Controllers
{
    public class AccuWeatherController : Controller
    {
        private readonly IAccuWeatherServices _accuweatherServices;

        public AccuWeatherController(IAccuWeatherServices accuweatherServices)
        {
            _accuweatherServices= accuweatherServices;

        }

       

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SearchCity(SearchAccuWeatherCityViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("AccuWeathers", "AccuWeather", new { city = model.CityName });
            }
            return View(model);

        }



        [HttpGet]

        public IActionResult AccuWeathers( string city)
        {
            AccuWeatherResultDto dto = new AccuWeatherResultDto();
            dto.City = city;

            _accuweatherServices.AccuWeatherResult(dto);
            AccuWeatherViewModel vm2 = new();

            
            vm2.DailyForecastDate= dto.DailyForecastDate;
            vm2.DailyForecastDaysHasPrecipitation=dto.DailyForecastDaysHasPrecipitation;
            vm2.DailyForecastTemperaturesMinimumsUnit = dto.DailyForecastTemperaturesMinimumsUnit;
            vm2.DailyForecastEpochDate= dto.DailyForecastEpochDate;
            vm2.HeadlinesText= dto.HeadlinesText;
            vm2.HeadlinesLink= dto.HeadlinesLink;

            
            return View(vm2);

        }





    }
}
