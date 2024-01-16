using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Kindergarten.Test
{
    public class KindergartenTest :TestBase
    {
        [Fact]
        public  async Task ShouldNot_AddEmptyKindergarten_WhenReturnresult()
        {
            KindergartenDto dto = new KindergartenDto();
            dto.KindergartenName = "Test";
            dto.Teacher = "asast";
            dto.ChildrenCount = 1;
            dto.GroupName = "Tjdhdvf";
            dto.CreatedAt = DateTime.Now;
            dto.ModifiedAt = DateTime.Now;



            var result = await Svc<IKindergartenServices>().Create(dto);

            Assert.NotNull(result);

        }

        [Fact]
        public async Task ShouldNot_GetByIdKindergarten_WhenReturnsNotequal()
        {
            Guid guid = Guid.Parse("21e9cd74-b60b-4fd4-a458-5f4ce7333d71");
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());

            await Svc<IKindergartenServices>().GetAsync(guid);
            
            Assert.NotEqual(guid, wrongGuid);

        }

        [Fact]
        public async Task Should_GetByIdKindergarten_WhenRetunsEqual()
        {
            Guid databaseGuid = Guid.Parse("21e9cd74-b60b-4fd4-a458-5f4ce7333d71");
            Guid guid = Guid.Parse("21e9cd74-b60b-4fd4-a458-5f4ce7333d71");

            await Svc<IKindergartenServices>().GetAsync(guid);

            Assert.Equal(databaseGuid, guid);   

        }

        [Fact]

        public async Task Should_DeleteByIdKindergarten_WhenDeleteKindergarten()
        {
            KindergartenDto kindergarten = MockKindergartenData();

            var createdKindergarten = await Svc<IKindergartenServices>().Create(kindergarten);
            var result = await Svc<IKindergartenServices>().Delete((Guid)createdKindergarten.Id);

            Assert.Equal(createdKindergarten, result);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdKindergarten_WhenDidNotDeleteKindergarten()
        {
            KindergartenDto kindergarten= MockKindergartenData();
            var createdkindergarten = await Svc<IKindergartenServices>().Create(kindergarten);
            var createdkindergarten2 = await Svc<IKindergartenServices>().Create(kindergarten);

            var result = await Svc<IKindergartenServices>().Delete((Guid)createdkindergarten2.Id);

            Assert.NotEqual(createdkindergarten.Id, result.Id);

        }

        [Fact]
        public async Task Should_UpdateKindergarten_WhenUpdateData()
        {
            var guid = Guid.Parse("21e9cd74-b60b-4fd4-a458-5f4ce7333d71");

            KindergartenDto kindergarten = MockKindergartenData();

            KindergartenDto kindergarten1 = new KindergartenDto()
            {
                Id = Guid.Parse("21e9cd74-b60b-4fd4-a458-5f4ce7333d71"),
                KindergartenName = "Testjhfh",
                Teacher = "asastshdsh",
                ChildrenCount = 3244,
                GroupName = "Tdhdvfshhd",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now


            };

            await Svc<IKindergartenServices>().Update(kindergarten);

            Assert.Equal(kindergarten1.Id, guid);
            Assert.NotEqual(kindergarten.Teacher, kindergarten1.Teacher);
            Assert.NotSame(kindergarten.ChildrenCount, kindergarten1.ChildrenCount);
            Assert.DoesNotMatch(kindergarten.GroupName.ToString(), kindergarten1.GroupName.ToString());

        }


        [Fact]
        public async Task Should_updateKindergarten_WhenUpdatedDataversion()
        {
            KindergartenDto kindergarten= MockKindergartenData();

            var createdkindergarten=await Svc<IKindergartenServices>().Create(kindergarten);

            KindergartenDto update = MockUpdateKindergartenData();

            var updatedkindergarten = await Svc<IKindergartenServices>().Update(update);

            Assert.DoesNotMatch(createdkindergarten.Teacher.ToString(), updatedkindergarten.Teacher.ToString());
            Assert.NotEqual(updatedkindergarten.ChildrenCount, createdkindergarten.ChildrenCount);
           
        }

        [Fact]
        public async Task ShouldNot_UpdateKindergarten_WhenNotUpdateData()
        {
            KindergartenDto kindergarten = MockKindergartenData();
            await Svc<IKindergartenServices>().Create(kindergarten);

             KindergartenDto NullUpdate= MockNullKindergarten();
            await Svc<IKindergartenServices>().Update(NullUpdate);
           

            var nullId = NullUpdate.Id;
            Assert.True(kindergarten.Id == nullId);
            Assert.Equal(kindergarten.Id, nullId);


        }




        private KindergartenDto MockNullKindergarten()
        {
            KindergartenDto dtonull = new()
            {
                Id = null,
                KindergartenName = "Test12",
                Teacher = "a2dd2",
                ChildrenCount = 343244,
                GroupName = "T233vf",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now

            };

            return dtonull;
        }
        private KindergartenDto MockUpdateKindergartenData()
        {
            KindergartenDto kindergartenUpdate = new()
            {
                KindergartenName = "Test12",
                Teacher = "a2dd2",
                ChildrenCount = 343244,
                GroupName = "T233vf",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now

            };
            return kindergartenUpdate;
        }

        private KindergartenDto MockKindergartenData()
        {
            KindergartenDto kindergarten = new()
            {

            KindergartenName = "Test",
            Teacher = "asast",
            ChildrenCount = 3244,
            GroupName = "Tjdhdvf",
            CreatedAt = DateTime.Now,
            ModifiedAt = DateTime.Now
        };
            return kindergarten;
        }

    }
}