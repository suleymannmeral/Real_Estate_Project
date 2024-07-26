using RealEstate_Dapper_Api.Dtos.ChartDto;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashBoardRepositories.ChartRepositories
{
    public interface IChartRepositories
    {
        Task<List<ResultChartDtos>> Get5CityOfChart();

    }
}
