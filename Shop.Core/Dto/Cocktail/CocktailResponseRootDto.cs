using Shop.Core.Dto.OpenWeatherDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shop.Core.Dto.Cocktail
{
    public class CocktailResponseRootDto
    {

        [JsonPropertyName("drinks")]
        public List<Drink> Drinks { get; set; }

    }
}
