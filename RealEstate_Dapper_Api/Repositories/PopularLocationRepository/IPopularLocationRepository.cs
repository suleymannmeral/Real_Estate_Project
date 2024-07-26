using RealEstate_Dapper_Api.Dtos.PopularLocationDto;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
        void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto);
        void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto);

        void DeletePopularLocation(int id);
        Task<GetByIdPopularLocationDto> GetPopularLocationById(int id);



    }
}
