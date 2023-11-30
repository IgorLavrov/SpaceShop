using Nancy.Json;
using Shop.Core.Dto.ChuckNorris;
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
    public class ChuckNorrisServices : IChuckNorrisServices
    {




        public async Task<ChuckNorrisResultDto> ChuckNorrisResult(ChuckNorrisResultDto dto)
        {

            string url = $"https://api.chucknorris.io/jokes/random";


            using (WebClient client = new WebClient())
            {

                string json = client.DownloadString(url);
                ChuckNorrisResponseRootDto ChuckNorrisResult = new JavaScriptSerializer().Deserialize<ChuckNorrisResponseRootDto>(json);
                //dto.Categories = ChuckNorrisResult.Categories[0];
                dto.CreatedAt = ChuckNorrisResult.Created_At;
                dto.IconUrl = ChuckNorrisResult.Icon_Url;
                dto.Url = ChuckNorrisResult.Url;
                dto.Id = ChuckNorrisResult.Id;
                dto.UpdatedAt = ChuckNorrisResult.Updated_At;
                dto.Value = ChuckNorrisResult.Value;

            }

            return dto;

        }
    }
}