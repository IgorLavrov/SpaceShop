using Nancy.Json;
using Shop.Core.Dto.Cocktail;
using Shop.Core.Dto.OpenWeatherDto;
using Shop.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ApplicationServices.Services
{
    public  class CocktailServices: ICocktailServices
    {

        public async Task<CocktailResultDto> OpenCocktailResult(CocktailResultDto dto)
        {

            
            string url = $"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={dto.strDrink}";


            using (WebClient client = new WebClient())
            {

                string json = client.DownloadString(url);
                CocktailResponseRootDto CocktailResult = new JavaScriptSerializer().Deserialize<CocktailResponseRootDto>(json);
                //if(CocktailResult != null)
                //{
                   
                //}
                dto.strDrink = CocktailResult.Drinks[0].strDrink;
                dto.isDrink = CocktailResult.Drinks[0].strDrink;
                dto.strDrinkThumb = CocktailResult.Drinks[0].strDrinkThumb;
                dto.strIngredient11 = CocktailResult.Drinks[0].strIngredient11;
                dto.strIngredient12 = CocktailResult.Drinks[0].strIngredient12;
                dto.strIngredient10 = CocktailResult.Drinks[0].strIngredient10;
                dto.strIngredient1 = CocktailResult.Drinks[0].strIngredient1;
                dto.strIngredient2 = CocktailResult.Drinks[0].strIngredient2;
                dto.strIngredient3 = CocktailResult.Drinks[0].strIngredient3;
                dto.strIngredient4 = CocktailResult.Drinks[0].strIngredient4;
                dto.strIngredient5 = CocktailResult.Drinks[0].strIngredient5;
                dto.strIngredient6 = CocktailResult.Drinks[0].strIngredient6;
                dto.strIngredient7 = CocktailResult.Drinks[0].strIngredient7;
                dto.strIngredient8 = CocktailResult.Drinks[0].strIngredient8;
                dto.strIngredient9 = CocktailResult.Drinks[0].strIngredient9;
                dto.strIngredient13 = CocktailResult.Drinks[0].strIngredient13;
                dto.strIngredient14 = CocktailResult.Drinks[0].strIngredient14;
                dto.strIngredient15 = CocktailResult.Drinks[0].strIngredient15;
                dto.strAlcoholic = CocktailResult.Drinks[0].strAlcoholic;
                dto.strDrinkAlternate = CocktailResult.Drinks[0].strDrinkAlternate;
                dto.strCreativeCommonsConfirmed = CocktailResult.Drinks[0].strCreativeCommonsConfirmed;
                dto.strMeasure1 = CocktailResult.Drinks[0].strMeasure1;
                dto.strMeasure2 = CocktailResult.Drinks[0].strMeasure2;
                dto.strMeasure3 = CocktailResult.Drinks[0].strMeasure3;
                dto.strMeasure4 = CocktailResult.Drinks[0].strMeasure4;
                dto.strMeasure5 = CocktailResult.Drinks[0].strMeasure5;
                dto.strMeasure6 = CocktailResult.Drinks[0].strMeasure6;
                dto.strMeasure7 = CocktailResult.Drinks[0].strMeasure7;
                dto.strMeasure8 = CocktailResult.Drinks[0].strMeasure8;
                dto.strMeasure9 = CocktailResult.Drinks[0].strMeasure9;
                dto.strMeasure10 = CocktailResult.Drinks[0].strMeasure10;
                dto.strMeasure11 = CocktailResult.Drinks[0].strMeasure11;
                dto.strMeasure12 = CocktailResult.Drinks[0].strMeasure12;
                dto.strMeasure13 = CocktailResult.Drinks[0].strMeasure13;
                dto.strMeasure14 = CocktailResult.Drinks[0].strMeasure14;
                dto.strMeasure15 = CocktailResult.Drinks[0].strMeasure15;
                dto.strGlass = CocktailResult.Drinks[0].strGlass;
                dto.strInstructions = CocktailResult.Drinks[0].strInstructions;
                dto.strInstructionsDE = CocktailResult.Drinks[0].strInstructionsDE;
                dto.strImageSource = CocktailResult.Drinks[0].strImageSource;
                dto.dateModified = CocktailResult.Drinks[0].dateModified;
    
                dto.strImageSource = CocktailResult.Drinks[0].strImageSource;
                dto.strInstructionsIT = CocktailResult.Drinks[0].strInstructionsIT;






            }

            return dto;

        }
    }
}
