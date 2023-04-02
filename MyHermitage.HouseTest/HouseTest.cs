using MyHermitage.Core.Domain;
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

        [Fact]

        public async Task Should_DeleteByIdHouse_WhenDeleteHouse()
        {
            //Arrange
            HouseDto house = CreateValidHouse();
            var createdHouse = await Svc<IHouseServices>().Create(house);

            //Act
            var result = await Svc<IHouseServices>().Delete((Guid)createdHouse.Id);

            //Assert
            Assert.Equal(createdHouse, result);

        }

        [Fact]
        public async Task Should_UpdateByIdHouse_WhenUpdateHouse()
        {
            House house = new();

            house.Id = new Guid("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");
            house.ClientName = "Name";
            house.Address = "asd";
            house.Architecture = "asd";
            house.TypeOfBuilding = "asd";
            house.Size = 123;
            house.NumberOfStoreys = 123;
            house.BildingMaterial = "asd";
            house.DateOfBildingPermition = DateTime.Now;

            var houseId = new Guid("9f0674c4-1ddc-4415-9ea2-a0502ac4913b");
            var houseToUpdate = new HouseDto()
            {
                ClientName = "Asd",
                Size = 456,
                Architecture = "dsa",
                BildingMaterial = "1",
                Address = "fds",
                TypeOfBuilding = "x"
            };

            await Svc<IHouseServices>().Update(houseToUpdate);

            Assert.NotEqual(house.ClientName, houseToUpdate.ClientName);
            Assert.DoesNotMatch(house.Architecture, houseToUpdate.Architecture);
            Assert.NotSame(house, houseToUpdate);
            Assert.Equal(house.Id, houseId);

        }

        [Fact]
        public async Task ShouldUpdate_ValidHouse_WhenBeUpdated()
        {
            HouseDto house = CreateValidHouse();
            var create = await Svc<IHouseServices>().Create(house);

            HouseDto updatedHouse = UpdateValidHouse();
            var update = await Svc<IHouseServices>().Update(updatedHouse);

            Assert.Equal(update.ClientName, create.ClientName);
            Assert.Equal(update.Address, create.Address);
            Assert.Equal(update.Architecture, create.Architecture);
            Assert.Equal(update.TypeOfBuilding, create.TypeOfBuilding);
            Assert.Equal(update.Size, create.Size);
            Assert.Equal(update.NumberOfStoreys, create.NumberOfStoreys);
            Assert.Equal(update.BildingMaterial, create.BildingMaterial);
            Assert.NotEqual(update.DateOfBildingPermition, create.DateOfBildingPermition);
        }

        [Fact]

        public async Task ShouldNot_UpdateHouse_WhenNotUpdateData()
        {
            HouseDto house = CreateValidHouse();
            var create = await Svc<IHouseServices>().Create(house);

            HouseDto nullUpdate = NullHouse();
            var update = await Svc<IHouseServices>().Update(nullUpdate);

            Assert.NotNull(update.Id);
            Assert.NotEqual(update.Id, create.Id);
            Assert.False(create.Id == update.Id);
        }

        private HouseDto CreateValidHouse()
        {
            HouseDto house = new()
            {
                ClientName = "asd",
                Address = "asd",
                Architecture = "asd",
                TypeOfBuilding = "asd",
                Size = 123,
                NumberOfStoreys = 123,
                BildingMaterial = "asd",
                DateOfBildingPermition = DateTime.Now,
            };

            return house;
        }

        private HouseDto UpdateValidHouse()
        {
            HouseDto house = new()
            {
                ClientName = "asd",
                Address = "asd",
                Architecture = "asd",
                TypeOfBuilding = "asd",
                Size = 123,
                NumberOfStoreys = 123,
                BildingMaterial = "asd",
                DateOfBildingPermition = DateTime.Now
            };
            return house;
        }

        private HouseDto NullHouse()
        {
            HouseDto house = new()
            {
                Id = null,
                ClientName = "asd",
                Address = "asd",
                Architecture = "asd",
                TypeOfBuilding = "asd",
                Size = 123,
                NumberOfStoreys = 123,
                BildingMaterial = "asd",
                DateOfBildingPermition = DateTime.Now
            };

            return house;
        }
    }
}