using Dapper;
using RealEstate_Dapper_Api.Dtos.ServicesDto;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDto;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServicesRepository
{
    public class ServicesRepository : IServicesRepository
    {

        private readonly Context _context;

        public ServicesRepository(Context context)
        {
            _context = context;
        }
        public async void CreateServices(CreateServicesDto createServicesDto)
        {
            var query = ("Insert into Services (ServiceName,ServiceStatus) values(@servicename,@servicestatus)");
            var paramaters = new DynamicParameters();
            paramaters.Add("@servicename", createServicesDto.ServiceName);
            paramaters.Add("@servicestatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }

             


        }

      
    }
}
