using Dapper;
using RealEstate_Dapper_Api.Dtos.AppUserDtos;
using RealEstate_Dapper_Api.Dtos.ProductImageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AppUserRepositories
{
    public class AppUserRepository:IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultAgentDto>> GetAgentByUserRole()
        {
            string query = "Select * from Users where UserRole=5";
         
            using (var connection = _context.CreateConnection())
            {

                var values = await connection.QueryAsync<ResultAgentDto>(query);
                return values.ToList();
           

            }
        }

        public async Task<GetAppUserByProductIDDto> GetAppUserByProductID(int id)
        {
            string query = "Select * from Users where UserID=@userid";
            var parameters = new DynamicParameters();
            parameters.Add("@userid", id);
            using (var connection = _context.CreateConnection())
            {

                var values = await connection.QueryFirstOrDefaultAsync<GetAppUserByProductIDDto>(query,parameters);
                if (values != null)
                {
                    return values;
                }
                else
                {
                    throw new Exception("User not Found");
                }


            }
        }
    }
}
