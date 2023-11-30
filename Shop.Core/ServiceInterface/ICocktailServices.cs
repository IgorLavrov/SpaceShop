using Shop.Core.Dto.Cocktail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ServiceInterface

{ 
    public  interface ICocktailServices
    {
        Task<CocktailResultDto> OpenCocktailResult(CocktailResultDto dto);

    }
}
