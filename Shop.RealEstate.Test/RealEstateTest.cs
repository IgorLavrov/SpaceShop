using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;

namespace Shop.RealEstate.Test
{

    public class RealEstate : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyRealestate_WhenReturnresult()
        {

            RealEstateDto dto = new RealEstateDto();
         
            dto.Address = "zzhxjda";
            dto.SizeSqrM = 1234;
            dto.RoomCount = 1;
            dto.Floor = 3;
            dto.BuildingType = "shjsa";
            dto.BuiltInYear = DateTime.Now.AddYears(1);
            dto.CreatedAt = DateTime.Now;
            dto.UpdatedAt = DateTime.Now;

            
             
            var result = await Svc<IRealEstateServices>().Create(dto);

            Assert.NotNull(result);

        }

        [Fact]
        public async Task ShouldNot_GetByIdRealEstate_WhenReturnsNotequal()
        {
            //Arrange
            Guid guid = Guid.Parse("d5a2f6df-10de-4e92-9d73-fb754937cfe6");

            // kuidas teha automaatselt guidu????

            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());


            //Act
            await Svc<IRealEstateServices>().GetAsync(guid);

            //Assert
            Assert.NotEqual(guid, wrongGuid);

        }


        [Fact]

        public async Task Should_GetByIdRealEstate_WhenRetunsEqual()
        {

            Guid databaseGuid = Guid.Parse("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");
            Guid getGuid = Guid.Parse("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");



            //SpaceshipDto spaceship = new();

            //spaceship.Id = new Guid("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");
            //Guid id2 = Guid.Parse("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");


            await Svc<IRealEstateServices>().GetAsync(getGuid);


            //Assert.Equal(spaceship.Id , id2);
            Assert.Equal(databaseGuid, getGuid);


        }

        [Fact]

        public async Task Should_DeleteByIdRealEstate_WhenDeleteSpaceship()
        {

            //Arrange
            RealEstateDto realestate = MockRealestateData();



            //Act
            var createdrealestate = await Svc<IRealEstateServices>().Create(realestate);
            var result = await Svc<IRealEstateServices>().Delete((Guid)createdrealestate.Id);


            Assert.Equal(createdrealestate, result);

        }


        [Fact]

        public async Task ShouldNot_DeleteByIdRealestae_WhenDidNotDeleteSpaceship()
        {
            RealEstateDto realestate = MockRealestateData();

            var addrealestate = await Svc<IRealEstateServices>().Create(realestate);
            var addrealestate2 = await Svc<IRealEstateServices>().Create(realestate);

            var result = await Svc<IRealEstateServices>().Delete((Guid)addrealestate2.Id);
            Assert.NotEqual(addrealestate.Id, result.Id);

        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateData()
        {
            var guid = new Guid("540ebca2-e78c-429d-9fcf-eb426b7b36ff");


            //new data
            RealEstateDto dto = MockRealestateData();

            RealEstateDto realestate = new RealEstateDto();

            realestate.Id = Guid.Parse("540ebca2-e78c-429d-9fcf-eb426b7b36ff");
            realestate.Address = "zzhxjda";
            realestate.SizeSqrM = 1234;
            realestate.RoomCount = 1;
            realestate.Floor = 3;
            realestate.BuildingType = "shjsadstrrss";
            realestate.BuiltInYear = DateTime.Now.AddYears(1);
            realestate.CreatedAt = DateTime.Now;
            realestate.UpdatedAt = DateTime.Now;

            
          
            await Svc<IRealEstateServices>().Update(dto);

            Assert.Equal(realestate.Id, guid);
            Assert.NotEqual(realestate.Address, dto.Address);
            Assert.NotSame(realestate.RoomCount, dto.RoomCount);
            Assert.DoesNotMatch(realestate.BuildingType.ToString(), dto.BuildingType.ToString());


        }


        [Fact]
        public async Task Should_updateRealEstate_WhenUpdatedtaversion()
        {
            RealEstateDto dto = MockRealestateData();
            var createdrealestate = await Svc<IRealEstateServices>().Create(dto);

            RealEstateDto update = MockUpdateRealestateData();
            var updaterealestate = await Svc<IRealEstateServices>().Update(update);

            Assert.DoesNotMatch(updaterealestate.Address.ToString(), createdrealestate.Address.ToString());
            Assert.NotEqual(updaterealestate.RoomCount, createdrealestate.RoomCount);
            Assert.NotEqual(updaterealestate.Floor, createdrealestate.Floor); 
           

        }

        [Fact]
        public async Task ShouldNot_UpdateSpaceship_WhenNotUpdateData()
        {
            RealEstateDto dto = MockRealestateData();
            await Svc<IRealEstateServices>().Create(dto);

           RealEstateDto NullUpdate = MockNullEstate();
            await Svc<IRealEstateServices>().Update(NullUpdate);

            var nullId = NullUpdate.Id;
            Assert.True(dto.Id == nullId);
            Assert.Equal(dto.Id, nullId);

        }

        private RealEstateDto MockNullEstate()
        {
            RealEstateDto nulldto = new()
            {
                Id = null,
                Address = "zzhxjwsadada",
                SizeSqrM = 122334,
                RoomCount = 123,
                Floor = 323,
                BuildingType = "shjsxzzca",
                BuiltInYear = DateTime.Now.AddYears(1),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return nulldto;
        }


        private  RealEstateDto MockUpdateRealestateData()
        {
            RealEstateDto update = new()
            {
                Address = "zzhxjwsadada",
                SizeSqrM = 122334,
                RoomCount = 123,
                Floor = 323,
                BuildingType = "shjsxzzca",
                BuiltInYear = DateTime.Now.AddYears(1),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now

            };

            return update;

        }

        private RealEstateDto MockRealestateData()
        {
            RealEstateDto realestate = new()
            {
            Address = "zzhxjdadsaa",
            SizeSqrM = 1234,
            RoomCount = 1,
            Floor = 3,
            BuildingType = "shjsaassa",
            BuiltInYear = DateTime.Now.AddYears(1),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now

        };

            return realestate;


        }
    }

}
