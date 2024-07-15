using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
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

        public async Task<List<ResultServiceDto>> GetServicesAsync()
        {
            string query = "Select * From Services";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();

            }

        }

        public async void UpdateServices(UpdateServicesDto updateServicesDto)
        {
            string query = ("Update Services set ServiceName=@servicename,ServiceStatus=@servicestatus where ServiceID=@serviceid");
            var parameters = new DynamicParameters();
            parameters.Add("@servicename",updateServicesDto.ServiceName);
            parameters.Add("@servicestatus", updateServicesDto.ServiceStatus);
            parameters.Add("@serviceid", updateServicesDto.ServiceID);


            using ( var connection = _context.CreateConnection())
            {
                var values = await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
