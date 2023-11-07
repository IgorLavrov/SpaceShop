using System.Text.Json.Serialization;

namespace Shop.Core.Dto.OpenWeatherDto
{
    public class Sys
    {
        [JsonPropertyName("type")]
        public int type { get; set; }
        [JsonPropertyName("id")]
        public int id {  get; set; }
        [JsonPropertyName("country")]

        public string country { get; set; }
        [JsonPropertyName("sunrise")]

        public double Sunrise { get; set; }

        [JsonPropertyName("sunset")]

        public double sunset { get; set; }

    }
}