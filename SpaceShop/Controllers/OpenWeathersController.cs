using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto.OpenWeatherDto;
using Shop.Core.ServiceInterface;
using SpaceShop.Models.OpenWeathers;

namespace SpaceShop.Controllers
{
    public class OpenWeathersController : Controller
    {
        private readonly IWeatherForecastServices _weatherForecastServices;

        public OpenWeathersController (IWeatherForecastServices weatherForecastServices)
       {
            _weatherForecastServices = weatherForecastServices;

         }

        public IActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public IActionResult SearchCity(SearchCityViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City","OpenWeathers",new {city=model.CityName});
            }
            return View(model);

        }

        [HttpGet]

        public IActionResult City(string city)
        {
            OpenWeatherResultDto dto = new OpenWeatherResultDto();
            dto.City = city;

            _weatherForecastServices.OpenWeatherResult(dto);
            OpenWeatherViewModel vm = new();

            vm.City = dto.City;
            vm.Lon=dto.Lon;
            vm.Lat=dto.Lat;
            vm.Name = dto.Name;
            vm.WeatherId = dto.WeatherId;
            vm.Country = dto.Country;
            vm.WeatherMain = dto.WeatherMain;
            vm.Dt = dto.Dt;
            vm.WeatherIcon = dto.WeatherIcon;
            vm.TemperaturePressure = dto.TemperaturePressure;
            vm.Temperature = dto.Temperature;
            vm.TemperatureMin = dto.TemperatureMin;
            vm.TemperatureMax = dto.TemperatureMax; 
            vm.Humidity = dto.Humidity;
            vm.Visibility = dto.Visibility;
            vm.Base= dto.Base;
            vm.CloudsAll = dto.CloudsAll;
            vm.FeelLikeTemperature = dto.FeelLikeTemperature;
            vm.SysId = dto.SysId;
            vm.WindDeg = dto.WindDeg;
            vm.WindDeg= dto.WindDeg;
            vm.Timezone = dto.Timezone;
            vm.Windspeed= dto.Windspeed;
            vm.Cod= dto.Cod;
            vm.WeatherDesciption = dto.WeatherDesciption;
            vm.SysType = dto.SysType;
            vm.Sunrise = dto.Sunrise;
            vm.Sunset = dto.Sunset;
            vm.Id = dto.Id;

            return View(vm);

        }
    }
}
