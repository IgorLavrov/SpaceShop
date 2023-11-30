using Shop.Core.Dto.Accuweather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ServiceInterface
{
    public interface IAccuWeatherServices
    {
        public Task<AccuWeatherResultDto> AccuWeatherResult(AccuWeatherResultDto dto);

        
    }
}
