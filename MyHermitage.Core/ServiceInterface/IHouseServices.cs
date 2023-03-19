using MyHermitage.Core.Domain;
using MyHermitage.Core.Dto;


namespace MyHermitage.Core.ServiceInterface
{
    public interface IHouseServices : IApplicationServices
    {
        Task<House> Create(HouseDto dto);
        Task<House> GetAsync(Guid Id);
        Task<House> Update(HouseDto dto);
        Task<House> Delete(Guid dto);
    }
}
