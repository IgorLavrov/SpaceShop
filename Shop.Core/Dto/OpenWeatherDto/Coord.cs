using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shop.Core.Dto.OpenWeatherDto
{
    public class Coord
    {
        [JsonPropertyName("Lon")]
        public double Lon {  get; set; }


        [JsonPropertyName("Lat")]
        public double Lat { get; set; }
       

}
}
