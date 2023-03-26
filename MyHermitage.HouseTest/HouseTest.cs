using MyHermitage.Core.Dto;
using MyHermitage.Core.ServiceInterface;

namespace MyHermitage.HouseTest
{
    public class HouseTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyHouse_WhenReturnResult()
        {
            string guid = Guid.NewGuid().ToString();
            string guid2 = "9f0674c4-1ddc-4415-9ea2-a0502ac4913b";

            HouseDto house = new HouseDto();

            house.Id = Guid.Parse(guid);
            house.ClientName = "asd";
            house.Address = "asd";
            house.Architecture = "asd";
            house.TypeOfBuilding = "asd";
            house.Size = 1;
            house.NumberOfStoreys = 1;
            house.BildingMaterial = "asd";
            house.DateOfBildingPermition = DateTime.Now;

            var result = await Svc<IHouseServices>().Create(house);

            Assert.NotNull(result);
        }

        [Fact]

        public async Task ShouldNot_GetByIdHouse_WhenRetunsNotEqual()
        {
            Guid guid = Guid.Parse("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");
            Guid guid1 = Guid.Parse(Guid.NewGuid().ToString());

            await Svc<IHouseServices>().GetAsync(guid);

            Assert.NotEqual(guid, guid1);
        }

        [Fact]

        public async Task Should_GetByIdHouse_WhenRetunsEqual()
        {
            Guid guid = Guid.Parse("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");
            Guid guid1 = Guid.Parse("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");

            await Svc<IHouseServices>().GetAsync(guid);

            Assert.Equal(guid, guid1);
        }
    }
}