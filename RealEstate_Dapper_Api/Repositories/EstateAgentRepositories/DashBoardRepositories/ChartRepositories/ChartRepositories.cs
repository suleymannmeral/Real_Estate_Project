using Dapper;
using RealEstate_Dapper_Api.Dtos.ChartDto;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashBoardRepositories.ChartRepositories
{
    public class ChartRepositories : IChartRepositories
    {

        private readonly Context _context;

        public ChartRepositories(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultChartDtos>> Get5CityOfChart()
        {
            string query = "Select Top(5) City,Count(*) as 'CityCount' From Product Group By City order by  CityCount Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultChartDtos>(query);
                return values.ToList();
            }
        }
    }
}
