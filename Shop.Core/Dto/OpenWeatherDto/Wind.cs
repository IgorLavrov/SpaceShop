using System.Text.Json.Serialization;

namespace Shop.Core.Dto.OpenWeatherDto
{
    public class Wind
    {
        [JsonPropertyName("speed")]
        public double speed { get; set; }

        [JsonPropertyName("deg")]
        public double degree { get; set; }
    }
}