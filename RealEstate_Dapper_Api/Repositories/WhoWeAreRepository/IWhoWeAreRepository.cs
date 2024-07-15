using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDto;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreRepository
    {
        Task<List<ResultWhoWeAreDto>> GetAllWhoWeAreAsync();

        void CreateWhoWeAre(CreateWhoWeAreDto whoWeAreDto);
        void DeleteWhoWeAre(int id);

        void UpdateWhoWeAre(UpdateWhoWeAreDto whoWeAreDto);

        Task<GetByIDWhoWeAreDto> GetWhoWeAre(int id);

    }
}
