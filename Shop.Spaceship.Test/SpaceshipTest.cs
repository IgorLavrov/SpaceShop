
using Microsoft.EntityFrameworkCore;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.SpaceshipTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Spaceship.Test
{
   public  class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnresult()
        {

            SpaceshipDto dto= new SpaceshipDto();
            dto.Name = "Name";
            dto.Type = "Type";
            dto.Passengers = 123;
            dto.EnginePower = 123;
            dto.Crew = 123;
            dto.Company = "asd";
            dto.CargoWeight = 123;
            dto.CreatedAt= DateTime.Now;
            dto.ModifiedAt= DateTime.Now;

            var result = await Svc<ISpaceshipServices>().Create(dto);

            Assert.NotNull(result);

        }

        [Fact]
        public async Task ShouldNot_GetByIdSpaceship_WhenReturnsNotequal()
        {
            Guid guid = Guid.Parse("d5a2f6df-10de-4e92-9d73-fb754937cfe6");
            // kuidas teha automaatselt guidu????
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());

        



        }

        
    }
}
