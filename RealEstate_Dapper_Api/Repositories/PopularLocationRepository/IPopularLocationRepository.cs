using RealEstate_Dapper_Api.Dtos.PopularLocationDto;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
        Task CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto);
        Task UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto);

        Task DeletePopularLocation(int id);
        Task<GetByIdPopularLocationDto> GetPopularLocationById(int id);



    }
}
