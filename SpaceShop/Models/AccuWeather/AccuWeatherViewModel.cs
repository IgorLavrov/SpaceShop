
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceShop.Models.AccuWeather
{
        public class AccuWeatherViewModel
    {


            public string City { get; set; }

            public DateTime HeadlinesEffectiveDate { get; set; }

            public string HeadlinesEffectiveEpochDate { get; set; }

            public string HeadlinesSeverity { get; set; }

            public string HeadlinesText { get; set; }

            public string HeadlinesCategory { get; set; }

            public DateTime HeadlinesEndDate { get; set; }

            public string HeadlinesEndEpochDate { get; set; }

            public string HeadlinesMobileLink { get; set; }

            public string HeadlinesLink { get; set; }

            public DateTime DailyForecastDate { get; set; }

            public int DailyForecastEpochDate { get; set; }

            public int DailyForecastTemperaturesMinimumsValue { get; set; }
            public string DailyForecastTemperaturesMinimumsUnit { get; set; }
            public int DailyForecastTemperaturesMinimumsUnitType { get; set; }

            public int DailyForecastTemperaturesMaximumsValue { get; set; }
            public string DailyForecastTemperaturesMaximumsUnit { get; set; }
            public int DailyForecastTemperaturesMaximumsUnitType { get; set; }


            public int DailyForecastDaysIcon { get; set; }


            public string DailyForecastDaysIconPhrase { get; set; }


            public string DailyForecastDaysHasPrecipitation { get; set; }


            public string DailyForecastDaysPrecipitationType { get; set; }


            public string DailyForecastDaysPrecipitationIntensity { get; set; }

            public int DailyForecastNightsIcon { get; set; }

            public string DailyForecastNightsIconPhrase { get; set; }

            public bool DailyForecastNightsHasPrecipitation { get; set; }

            public string DailyForecastSources { get; set; }

            public string DailyForecastMobileLink { get; set; }

            public string DailyForecastLink { get; set; }
        }


    }



