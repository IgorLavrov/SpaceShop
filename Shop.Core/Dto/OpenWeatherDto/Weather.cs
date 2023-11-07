using System.Text.Json.Serialization;

namespace Shop.Core.Dto.OpenWeatherDto
{
    public class Weather
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("main")]
        public string  main {  get; set; }
        
        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("icon")]
        public string icon { get; set; }



    }
}