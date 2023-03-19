using Microsoft.EntityFrameworkCore;
using MyHermitage.Core.Domain;
using MyHermitage.Core.Dto;
using MyHermitage.Core.ServiceInterface;
using MyHermitage.Data;

namespace MyHermitage.ApplicationServices.Services
{
    public class HouseServices : IHouseServices
    {
        private readonly MyHermitageDbContext _context;

        public HouseServices(MyHermitageDbContext context)
        {
            _context = context;
        }

        public async Task<House> Create(HouseDto dto)
        {
            House house = new House();

            house.Id = Guid.NewGuid();
            house.ClientName = dto.ClientName;
            house.Address = dto.Address;
            house.Architecture = dto.Architecture;
            house.TypeOfBuilding = dto.TypeOfBuilding;
            house.Size = dto.Size;
            house.NumberOfStoreys = dto.NumberOfStoreys;
            house.BildingMaterial = dto.BildingMaterial;
            house.DateOfBildingPermition = dto.DateOfBildingPermition;

            await _context.House.AddAsync(house);
            await _context.SaveChangesAsync();

            return house;
        }

        public async Task<House> GetAsync(Guid id)
        {
            var result = await _context.House
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<House> Update(HouseDto dto)
        {
            var house = new House()
            {
                Id = dto.Id,
                ClientName = dto.ClientName,
                Address = dto.Address,
                Architecture = dto.Architecture,
                TypeOfBuilding = dto.TypeOfBuilding,
                Size = dto.Size,
                NumberOfStoreys = dto.NumberOfStoreys,
                BildingMaterial = dto.BildingMaterial,
                DateOfBildingPermition = dto.DateOfBildingPermition,
            };

            _context.House.Update(house);
            await _context.SaveChangesAsync();

            return house;
        }

        public async Task<House> Delete(Guid Id)
        {
            var houseId = await _context.House
                .FirstOrDefaultAsync(x => x.Id == Id);

            _context.House.Remove(houseId);
            await _context.SaveChangesAsync();

            return houseId;
        }
    }
}
