using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shop.Core.Dto.OpenWeatherDto
{
    public class OpenedWeatherResponseRootDto
    {
        [JsonPropertyName("coord")]
        public Coord Coord { get; set; }

        [JsonPropertyName("weather")]
        public List<Weather> Weather { get; set; }

        [JsonPropertyName("base")]
        public string @Base { get; set; }

        [JsonPropertyName("main")]
        public Main main { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }
        [JsonPropertyName("wind")]
        public Wind wind { get; set; }
        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }
        [JsonPropertyName("dt")]
        public int dt { get; set; }
        [JsonPropertyName("sys")]
        public Sys system { get; set; }
        [JsonPropertyName("timezone")]
        public int TimeZone { get; set; }
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("cod")]
        public int cod { get; set; }
        [JsonPropertyName("snow")]
        public Snow Snow { get; set; }

        [JsonPropertyName("rain")]
        public Rain rain { get; set; }

    }
    
 

}
