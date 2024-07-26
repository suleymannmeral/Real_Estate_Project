using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashBoardRepositories.Last5ProductRepositories
{
    public interface ILast5ProductRepository
    {
        Task<List<ResultLast5Product>> GetLast5ProductByEmployeeIdAsync(int id);

    }
}
