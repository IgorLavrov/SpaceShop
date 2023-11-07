using System.Text.Json.Serialization;

namespace Shop.Core.Dto.OpenWeatherDto
{
    public class Clouds
    {
        [JsonPropertyName("id")]
        public int all {  get; set; }
    }
}