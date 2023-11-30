using System.ComponentModel.DataAnnotations;

namespace SpaceShop.Models.AccuWeather
{
    public class SearchAccuWeatherCityViewModel
    {
            [Required(ErrorMessage = "You must enter a city name!")]
            [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only text allowed")]
            [StringLength(20, MinimumLength = 2, ErrorMessage = "Enter a city name greater than 2 and lesser than 20 characters!")]
            [Display(Name = "City name")]
            public string CityName { get; set; }

        }
    }



