using System.Text.Json.Serialization;

namespace Shop.Core.Dto.OpenWeatherDto
{
    public class Main
    {
        [JsonPropertyName("temp")]
        public double Temp {  get; set; }

        [JsonPropertyName("feels_like")]
        public  double Feels_Like { get; set; }

        [JsonPropertyName("temp_min")]
        public double Temp_Min {  get; set; }
        [JsonPropertyName("temp_max")]
        public double Temp_Max { get; set; }
        [JsonPropertyName("pressure")]
        public  double Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public  int humidity { get; set; }


    }
}