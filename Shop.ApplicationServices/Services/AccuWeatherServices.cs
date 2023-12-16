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

        string number ="";
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
         

            string url2 = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{number}?apikey={idAccuweather}";//fareinheit
          //  string url2 = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{number}?apikey={idAccuweather}&metric=true";// temp celsium


            using (WebClient tclient = new WebClient())
            {


                string json1 = tclient.DownloadString(url2);
                AccuWeatherResponseRootDto AccuWeatherResult2 = new JavaScriptSerializer().Deserialize<AccuWeatherResponseRootDto>(json1);

                dto.DailyForecastDate = AccuWeatherResult2.DailyForecasts[0].Date;
                dto.HeadlinesText = AccuWeatherResult2.Headline.Text;
                dto.HeadlinesLink = AccuWeatherResult2.Headline.Link;
                dto.HeadlinesCategory = AccuWeatherResult2.Headline.Category;
                dto.DailyForecastEpochDate = AccuWeatherResult2.DailyForecasts[0].EpochDate;
                dto.DailyForecastDaysHasPrecipitation = AccuWeatherResult2.DailyForecasts[0].Day.HasPrecipitation;
                dto.DailyForecastDaysIcon = AccuWeatherResult2.DailyForecasts[0].Day.Icon;
                dto.DailyForecastDaysIconPhrase = AccuWeatherResult2.DailyForecasts[0].Day.IconPhrase;
                dto.DailyForecastNightsHasPrecipitation = AccuWeatherResult2.DailyForecasts[0].Night.HasPrecipitation;
                dto.DailyForecastNightsIcon = AccuWeatherResult2.DailyForecasts[0].Night.Icon;
                dto.DailyForecastNightsIconPhrase = AccuWeatherResult2.DailyForecasts[0].Night.IconPhrase;
                dto.DailyForecastSources = AccuWeatherResult2.DailyForecasts[0].Sources[0];
                dto.DailyForecastTemperaturesMaximumsUnit = AccuWeatherResult2.DailyForecasts[0].Temperature.Maximum.Unit;
                dto.DailyForecastTemperaturesMaximumsValue = AccuWeatherResult2.DailyForecasts[0].Temperature.Maximum.Value;
                dto.DailyForecastTemperaturesMinimumsUnit = AccuWeatherResult2.DailyForecasts[0].Temperature.Minimum.Unit;
                dto.DailyForecastTemperaturesMinimumsUnitType = AccuWeatherResult2.DailyForecasts[0].Temperature.Minimum.UnitType;

                dto.HeadlinesEffectiveEpochDate = AccuWeatherResult2.Headline.EffectiveEpochDate;
                dto.HeadlinesEndDate= AccuWeatherResult2.Headline.EndDate;
                dto.HeadlinesSeverity = AccuWeatherResult2.Headline.Severity;
                dto.DailyForecastTemperaturesMaximumsUnitType = AccuWeatherResult2.DailyForecasts[0].Temperature.Maximum.UnitType;
                dto.DailyForecastNightsHasPrecipitation = AccuWeatherResult2.DailyForecasts[0].Night.HasPrecipitation;
                dto.DailyForecastNightsIconPhrase = AccuWeatherResult2.DailyForecasts[0].Night.IconPhrase;
                dto.DailyForecastLink = AccuWeatherResult2.DailyForecasts[0].MobileLink;
                dto.HeadlinesEffectiveDate = AccuWeatherResult2.Headline.EffectiveDate;               
            }



            return dto;

        }



    }
}
