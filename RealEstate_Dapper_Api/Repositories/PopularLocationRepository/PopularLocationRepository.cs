using Dapper;
using RealEstate_Dapper_Api.Dtos.PopularLocationDto;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
    public class PopularLocationRepository:IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async Task CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = ("Insert Into PopularLocation (CityName,ImageURL) values (@cityname,@imageurl)");
            var parameters = new DynamicParameters();
            parameters.Add("@cityname", createPopularLocationDto.CityName);
            parameters.Add("@imageurl", createPopularLocationDto.ImageURL);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }


        }

        public async Task DeletePopularLocation(int id)
        {
            string query = ("Delete from PopularLocation where LocationID=@locationid");
            var paramaters = new DynamicParameters();
            paramaters.Add("@locationid", id);
            using (var connection = _context.CreateConnection())
            {
               await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            string query = "Select * From PopularLocation";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);

                return values.ToList();

            }  
        }

        public async Task<GetByIdPopularLocationDto> GetPopularLocationById(int id)
        {
            string query = "Select * From PopularLocation Where LocationId=@lid";
            var parameters = new DynamicParameters();
            parameters.Add("@lid", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            string query = ("Update PopularLocation Set CityName=@cityname,ImageURL=@imgurl where LocationID=@plid");

            var parameters = new DynamicParameters();
            parameters.Add("@cityname", updatePopularLocationDto.CityName);
            parameters.Add("@imgurl", updatePopularLocationDto.ImageURL);
            parameters.Add("@plid", updatePopularLocationDto.LocationID);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

            

        }
    }
}
