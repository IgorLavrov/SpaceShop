namespace SpaceShop.Models.OpenWeathers
{
    public class OpenWeatherViewModel
    {
        public string City { get; set; }

        public double Lon { get; set; }

        public double Lat { get; set; }

        public int WeatherId { get; set; }
        public string WeatherMain { get; set; }

        public string WeatherDesciption { get; set; }

        public string WeatherIcon { get; set; }

        public string Base { get; set; }

        public double Temperature { get; set; }
        public double FeelLikeTemperature { get; set; }

        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }

        public double TemperaturePressure { get; set; }

        public int Humidity { get; set; }

        public int Visibility { get; set; }
        public double Windspeed { get; set; }

        public double WindDeg { get; set; }

        public int CloudsAll { get; set; }

        public double Dt { get; set; }
        public int SysType { get; set; }

        public int SysId { get; set; }

        public string Country { get; set; }

        public double Sunrise { get; set; }

        public double Sunset { get; set; }

        public double Timezone { get; set; }

        public double Id { get; set; }

        public string Name { get; set; }

        public int Cod { get; set; }
    }
}
