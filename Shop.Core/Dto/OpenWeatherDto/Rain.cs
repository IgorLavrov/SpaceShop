using System.Text.Json.Serialization;

namespace Shop.Core.Dto.OpenWeatherDto
{
    public class Rain
    {
      
        [JsonPropertyName("1h")]
        public double double_1h {  get; set; }

        [JsonPropertyName("3h")]
        public double double_3h {  get; set; }
    }
}