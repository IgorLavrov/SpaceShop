using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Shop.Core.Dto.Accuweather
{
    public class DailyForecasts
    {
        
            [JsonProperty("Date")]
            public DateTime Date { get; set; }

            [JsonProperty("EpochDate")]
            public int EpochDate { get; set; }

            [JsonProperty("Temperature")]
            public Temperature Temperature { get; set; }

            [JsonProperty("Day")]
            public Day Day { get; set; }

            [JsonProperty("Night")]
            public Night Night { get; set; }

            [JsonProperty("Sources")]
            public List<string> Sources { get; set; }

            [JsonProperty("MobileLink")]
            public string MobileLink { get; set; }

            [JsonProperty("Link")]
            public string Link { get; set; }
        }

        public class Night
        {
            [JsonProperty("Icon")]
            public int Icon { get; set; }

            [JsonProperty("IconPhrase")]
            public string IconPhrase { get; set; }

            [JsonProperty("HasPrecipitation")]
            public bool HasPrecipitation { get; set; }
        }

        public class Day
        {
            [JsonProperty("Icon")]
            public int Icon { get; set; }

            [JsonProperty("IconPhrase")]
            public string IconPhrase { get; set; }

            [JsonProperty("HasPrecipitation")]
            public bool HasPrecipitation { get; set; }

            [JsonProperty("PrecipitationType")]
            public string PrecipitationType { get; set; }

            [JsonProperty("PrecipitationIntensity")]
            public string PrecipitationIntensity { get; set; }
        }

        public class Temperature
        {
            [JsonProperty("Minimum")]
            public Minimum Minimum { get; set; }

            [JsonProperty("Maximum")]
            public Maximum Maximum { get; set; }
        }

        public class Maximum
        {
            [JsonProperty("Value")]
            public int Value { get; set; }

            [JsonProperty("Unit")]
            public string Unit { get; set; }

            [JsonProperty("UnitType")]
            public int UnitType { get; set; }
        }

        public class Minimum
        {
            [JsonProperty("Value")]
            public int Value { get; set; }

            [JsonProperty("Unit")]
            public string Unit { get; set; }

            [JsonProperty("UnitType")]
            public int UnitType { get; set; }
        }


    }
