using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto.Cocktail;
using Shop.Core.Dto.OpenWeatherDto;
using Shop.Core.ServiceInterface;
using SpaceShop.Models.Cocktail;
using SpaceShop.Models.OpenWeathers;

namespace SpaceShop.Controllers
{
    public class CocktailController : Controller
    {
      

        private readonly ICocktailServices _CocktailServices;

        public CocktailController(ICocktailServices CocktailServices)
        {
            _CocktailServices = CocktailServices;

        }

        public IActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public IActionResult SearchCocktail(SearchCocktailViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Cocktails", "Cocktail", new { Newcocktail = model.Cocktail });
           }
            return View(model);

        }

        [HttpGet]

        public IActionResult Cocktails(string Newcocktail)
        {
            CocktailResultDto dto = new ();
            dto.strDrink = Newcocktail;

            _CocktailServices.OpenCocktailResult(dto);
             OpenCocktailViewModel vm = new();

            vm.Drink = dto.isDrink;
            vm.InstructionsIT = dto.strInstructionsIT;
            vm.Drink = dto.strDrink;
            vm.DrinkThumb = dto.strDrinkThumb;
            vm.Ingredient11 = dto.strIngredient11;
            vm.Ingredient12 = dto.strIngredient12;
            vm.Ingredient10 = dto.strIngredient10;
            vm.Ingredient1 = dto.strIngredient1;
            vm.Ingredient2 = dto.strIngredient2;
            vm.Ingredient3 = dto.strIngredient3;
            vm.Ingredient9 = dto.strIngredient9;
            vm.Ingredient13 = dto.strIngredient13;
            vm.Ingredient14 = dto.strIngredient14;
            vm.Ingredient15 = dto.strIngredient15;
            vm.Alcoholic = dto.strAlcoholic;
            vm.DrinkAlternate = dto.strDrinkAlternate;
            vm.CreativeCommons = dto.strCreativeCommonsConfirmed;
            vm.Measure1 = dto.strMeasure1;
            vm.Measure2 = dto.strMeasure2;
            vm.Measure3 = dto.strMeasure3;
            vm.Measure4 = dto.strMeasure4;
            vm.Measure5 = dto.strMeasure5;
            vm.Measure6 = dto.strMeasure6;
            vm.Measure7 = dto.strMeasure7;
            vm.Measure8 = dto.strMeasure8;
            vm.Measure9 = dto.strMeasure9;
            vm.Measure10 = dto.strMeasure10;
            vm.Measure11 = dto.strMeasure11;
            vm.Measure12 = dto.strMeasure12;
            vm.Measure13 = dto.strMeasure13;
            vm.Measure14 = dto.strMeasure14;
            vm.Measure15 = dto.strMeasure15;
            vm.InstructionsDE = dto.strInstructionsDE;
            vm.Instructions = dto.strInstructions;
            vm.Glass=dto.strGlass;
            vm.ImageSource = dto.strImageSource;
            vm.InstructionsES= dto.strInstructionsES;
            vm.InstructionsIT= dto.strInstructionsIT;
            vm.ImageAttribution= dto.strImageAttribution;
            vm.DrinkThumb= dto.strDrinkThumb;
            vm.InstructionsFR = dto.strInstructionsFR;
            vm.Tags= dto.strTags;


            return View(vm);

        }




    }

}
