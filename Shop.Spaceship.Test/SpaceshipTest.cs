
using Microsoft.EntityFrameworkCore;
using Shop.ApplicationServices.Services;
using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Spaceship.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Spaceship.Test
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnresult()
        {

            SpaceshipDto dto = new SpaceshipDto();
            dto.Name = "Name";
            dto.Type = "Type";
            dto.Passengers = 123;
            dto.EnginePower = 123;
            dto.Crew = 123;
            dto.Company = "asd";
            dto.CargoWeight = 123;
            dto.CreatedAt = DateTime.Now;
            dto.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipServices>().Create(dto);

            Assert.NotNull(result);

        }

        [Fact]
        public async Task ShouldNot_GetByIdSpaceship_WhenReturnsNotequal()
        {
            //Arrange
            Guid guid = Guid.Parse("d5a2f6df-10de-4e92-9d73-fb754937cfe6");

            // kuidas teha automaatselt guidu????

            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());


            //Act
            await Svc<ISpaceshipServices>().GetAsync(guid);

            //Assert
            Assert.NotEqual(guid, wrongGuid);

        }


        [Fact]

        public async Task Should_GetByIdSpaceship_WhenRetunsEqual()
        {

            Guid databaseGuid = Guid.Parse("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");
            Guid getGuid = Guid.Parse("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");



            //SpaceshipDto spaceship = new();

            //spaceship.Id = new Guid("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");
            //Guid id2 = Guid.Parse("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");


            await Svc<ISpaceshipServices>().GetAsync(getGuid);


            //Assert.Equal(spaceship.Id , id2);
            Assert.Equal(databaseGuid, getGuid);


        }

        [Fact]

        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {

            //Arrange
            SpaceshipDto spaceship = MockSpaceshipData();



            //Act
            var createdspaceship = await Svc<ISpaceshipServices>().Create(spaceship);
            var result = await Svc<ISpaceshipServices>().Delete((Guid)createdspaceship.Id);


            Assert.Equal(createdspaceship, result);

        }


        [Fact]

        public async Task ShouldNot_DeleteByIdSpaceship_WhenDidNotDeleteSpaceship()
        {
            SpaceshipDto spaceship = MockSpaceshipData();

            var addSpaceship = await Svc<ISpaceshipServices>().Create(spaceship);
            var addSpaceship2 = await Svc<ISpaceshipServices>().Create(spaceship);

            var result = await Svc<ISpaceshipServices>().Delete((Guid)addSpaceship2.Id);
            Assert.NotEqual(addSpaceship.Id, result.Id);

        }

        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateData()
        {
            var guid = new Guid("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");

            //old data from db
            Shop.Core.Domain.Spaceship spaceship = new Shop.Core.Domain.Spaceship();

            //new data
            SpaceshipDto dto = MockSpaceshipData();

            spaceship.Id = Guid.Parse("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");
            spaceship.Name = "asdrd";
            spaceship.Type = "asdasad";
            spaceship.Passengers = 123123;
            spaceship.EnginePower = 15423;
            spaceship.Crew = 567;
            spaceship.Company = "Company asd";
            spaceship.CargoWeight = 567;
            spaceship.CreatedAt = DateTime.Now.AddYears(1);
            spaceship.ModifiedAt=DateTime.Now.AddYears(1);

            await Svc<ISpaceshipServices>().Update(dto);

            Assert.Equal(spaceship.Id, guid);
            Assert.NotEqual(spaceship.EnginePower, dto.EnginePower);
            Assert.NotSame(spaceship.Name, dto.Name);
            //Assert.DoesNotMatch(Convert.ToString(spaceship.Passengers), dto.Passengers.ToString());
            Assert.DoesNotMatch(spaceship.Passengers.ToString(), dto.Passengers.ToString());


        }


        [Fact]
        public async Task Should_updateSpaceship_WhenUpdatedDataversion()
        {
            SpaceshipDto dto=MockSpaceshipData();
            var createdSpaceship=await Svc<ISpaceshipServices>().Create(dto);

            SpaceshipDto update = MockUpdateSpaceshipData();
            var updateSpaceship = await Svc<ISpaceshipServices>().Update(update);

            Assert.DoesNotMatch(updateSpaceship.Name.ToString(), createdSpaceship.Name.ToString());
            Assert.NotEqual(updateSpaceship.EnginePower, createdSpaceship.EnginePower);
            Assert.NotEqual(updateSpaceship.Crew, createdSpaceship.Crew);
            //Assert.DoesNotMatch(Convert.ToString(spaceship.Passengers), dto.Passengers.ToString());
            Assert.DoesNotMatch(updateSpaceship.Passengers.ToString(), createdSpaceship.Passengers.ToString());

        }

        [Fact]
        public async Task ShouldNot_UpdateSpaceship_WhenNotUpdateData()
        {
            SpaceshipDto dto=MockSpaceshipData();
            await Svc<ISpaceshipServices>().Create(dto);

            SpaceshipDto NullUpdate = MockNullSpaceship();
            await Svc<ISpaceshipServices>().Update(NullUpdate);

            var nullId=NullUpdate.Id;
            Assert.True(dto.Id==nullId);
            Assert.Equal(dto.Id, nullId);

        }

        private SpaceshipDto MockNullSpaceship()
        {
            SpaceshipDto nulldto = new()
            {
                Id =null,
                Name ="Name123",
                Type="type123",
                Passengers=123,
                EnginePower=123,
                Crew=123,
                Company="Company123",
                CargoWeight=123,
                CreatedAt=DateTime.Now.AddYears(1),
                ModifiedAt=DateTime.Now.AddYears(1),
            };
            return nulldto;
        }


        private SpaceshipDto MockUpdateSpaceshipData()
        {
            SpaceshipDto update = new()
            {
                Name = "asd123",
                Type = "asd",
                Passengers = 123456,
                EnginePower = 123456,
                Crew = 123456,
                Company = "asdasdasd",
                CargoWeight = 123456,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now

            };
            
            return update;

        }

        private  SpaceshipDto MockSpaceshipData()
        {
            SpaceshipDto spaceship = new()
            {

                Name = "asd",
                Type = "asd",
                Passengers = 123,
                EnginePower = 123,
                Crew = 123,
                Company = "asd",
                CargoWeight = 123,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now

            };

            return spaceship;
           

        }
    }
}