using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashBoardRepositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }
        public int AllProductCount()
        {
            string query = "Select Count(*) From Product  ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ProductCountByEmployeeID(int id)
        {
            string query = "Select Count(*) From Product where EmployeeID=@employeid";
            var paramaters = new DynamicParameters();
            paramaters.Add("@employeid", id);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query,paramaters);
                return values;
            }
        }

        public int ProductCountByStatusFalse(int id)
        {
            string query = "Select Count(*) From Product where EmployeeID=@employeid and ProductStatus=0";
            var paramaters = new DynamicParameters();
            paramaters.Add("@employeid", id);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, paramaters);
                return values;
            }
        }

        public int ProductCountByStatusTrue(int id)
        {
            string query = "Select Count(*) From Product where EmployeeID=@employeid and ProductStatus=1";
            var paramaters = new DynamicParameters();
            paramaters.Add("@employeid", id);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, paramaters);
                return values;
            }
        }
    }
}
