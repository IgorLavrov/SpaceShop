using System.Text.Json.Serialization;

namespace Shop.Core.Dto.OpenWeatherDto
{
    public class Main
    {
        [JsonPropertyName("temp")]
        public double Temperature {  get; set; }

        [JsonPropertyName("feels_like")]
        public  double FeelsLikeTemperature { get; set; }

        [JsonPropertyName("temp_min")]
        public double TemperatureMin {  get; set; }
        [JsonPropertyName("temp_max")]
        public double TemperatureMax { get; set; }
        [JsonPropertyName("pressure")]
        public  double Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public  int humidity { get; set; }


    }
}