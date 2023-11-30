using Nancy.Json;
using Newtonsoft.Json;
using Shop.Core.Dto.Accuweather;
using Shop.Core.ServiceInterface;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Shop.ApplicationServices.Services
{
   

    public class AccuWeatherServices : IAccuWeatherServices
    {

        string number =  "";
        string idAccuweather = "";

        public async Task<AccuWeatherResultDto> AccuWeatherResult (AccuWeatherResultDto dto)
        {
            string url = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={idAccuweather}&q={dto.City}";

            using (WebClient client = new WebClient())
            {

              string json = client.DownloadString(url);
              List< AccuWeatherResponseRootDto> AccuWeatherResult = new JavaScriptSerializer().Deserialize<List<AccuWeatherResponseRootDto>>(json);

                number= AccuWeatherResult[0].Key;

            }
         

            string url2 = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{number}?apikey={idAccuweather}";

            using (WebClient tclient = new WebClient())
            {


                string json1 = tclient.DownloadString(url2);
                AccuWeatherResponseRootDto AccuWeatherResult2 = new JavaScriptSerializer().Deserialize<AccuWeatherResponseRootDto>(json1);
                dto.AccuCitysKey = number;
                dto.DailyForecastDate = AccuWeatherResult2.DailyForecasts[0].Date;
                dto.HeadlinesText = AccuWeatherResult2.Headline.Text;
                dto.HeadlinesCategory = AccuWeatherResult2.Headline.Category;
                dto.DailyForecastEpochDate = AccuWeatherResult2.DailyForecasts[0].EpochDate;
                dto.DailyForecastDaysHasPrecipitation = AccuWeatherResult2.DailyForecasts[0].Day.HasPrecipitation;
                
            }



            return dto;

        }



    }
}
