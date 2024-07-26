using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashBoardRepositories.Last5ProductRepositories
{
    public class Last5ProductRepository:ILast5ProductRepository
    {
        private readonly Context _context;

        public Last5ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultLast5Product>> GetLast5ProductByEmployeeIdAsync(int id)
        {
            string query = "Select Top(5) ProductID,Title,Price,City,District,ProductCategory,CategoryName,advertDate From Product Inner Join Category On Product.ProductCategory=Category.CategoryID Where EmployeeID=@employeid Order By ProductID Desc";
            var paramaters = new DynamicParameters();
            paramaters.Add("@employeid", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5Product>(query, paramaters);
                return values.ToList();

            }
        }
    }
}
