using RealEstate_Dapper_Api.Dtos.AppUserDtos;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;

namespace RealEstate_Dapper_Api.Repositories.AppUserRepositories
{
    public interface IAppUserRepository
    {
        Task<GetAppUserByProductIDDto> GetAppUserByProductID(int id);
        Task<List<ResultAgentDto>> GetAgentByUserRole();

    }
}
