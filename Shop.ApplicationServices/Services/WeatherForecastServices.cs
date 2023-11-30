using Nancy.Json;
using Shop.Core.Dto.OpenWeatherDto;
using Shop.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ApplicationServices.Services
{

    public class WeatherForecastServices:IWeatherForecastServices
    {

        public async Task <OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto)
        {

            string idOpenweather = " "; 
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.City}&units=metric&appid={idOpenweather}";


            using (WebClient client = new WebClient())
            {

                string json = client.DownloadString(url);
                OpenedWeatherResponseRootDto weatherResult = new JavaScriptSerializer().Deserialize<OpenedWeatherResponseRootDto>(json);
                dto.City = weatherResult.name;
                dto.Temperature = weatherResult.Main.Temp;
                dto.Humidity = weatherResult.Main.humidity;
                dto.TemperaturePressure = weatherResult.Main.Pressure;
                dto.FeelLikeTemperature = weatherResult.Main.Feels_Like;
                dto.Windspeed = weatherResult.Wind.Speed;
                dto.WeatherDesciption = weatherResult.Weather[0].description;

            
            }

            return dto;

        }

    }

}
