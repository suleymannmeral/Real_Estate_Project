using RealEstate_Dapper_Api.Dtos.ServicesDto;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDto;

namespace RealEstate_Dapper_Api.Repositories.ServicesRepository
{
    public interface IServicesRepository
    {
       
        Task <List<ResultServiceDto>> GetServicesAsync();
        void CreateServices(CreateServicesDto createServicesDto);
        void UpdateServices(UpdateServicesDto updateServicesDto);
        Task<GetByIDServicesDto> GetServicesWithID(int id);
        void DeleteServices(int id );




    }
}
