using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDto;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
        Task DeleteBottomGrid(int id);
        Task UpdateBottomGrid (UpdateBottomGridDto updateBottomGridDto);

        Task CreateBottomGrid(CreateBottomGridDto createBottomGridDto);
        Task<GetByIDBottomGridDto> GetBottomGridWithID(int id);

    }
}
