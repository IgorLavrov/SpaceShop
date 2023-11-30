using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shop.Core.Dto.Accuweather
{
     public class AccuWeatherResponseRootDto
    {
              

        [JsonPropertyName("Key")]
        public string Key { get; set; }

        [JsonPropertyName("Headline")]
        public Headline Headline { get; set; }

        [JsonPropertyName("DailyForecasts")]
        public List <DailyForecasts> DailyForecasts { get; set; }


    }

   

  
}
