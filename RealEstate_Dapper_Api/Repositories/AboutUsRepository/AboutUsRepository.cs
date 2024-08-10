using Dapper;
using RealEstate_Dapper_Api.Dtos.AboutUsDtos;
using RealEstate_Dapper_Api.Dtos.ContactUsDto;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AboutUsRepository
{
    public class AboutUsRepository : IAboutUsRepository
    {
        private readonly Context _context;

        public AboutUsRepository(Context context)
        {
            _context = context;
        }

        public async Task<ResultAboutUsDto> GetAboutUsByID(int id)
        {

            string query = "Select * from AboutUs where AboutUsID=@id ";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultAboutUsDto>(query,parameters);
                return values;
            }
        }

        public async Task<List<ResultAboutUsDto>> GetAllAboutUs()
        {
            string query = "Select * from AboutUs ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAboutUsDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateAboutUs(UpdateAboutUsDto updateAboutUsDto)
        {
            string query = "Update AboutUs Set Title=@title,Description1=@desc1,Description2=@desc2,VideoLink=@video,Image=image where AboutUsID=@id";
            var paramaters = new DynamicParameters();
            paramaters.Add("@title",updateAboutUsDto.Title);
            paramaters.Add("@desc1",updateAboutUsDto.Description1);
            paramaters.Add("@desc2",updateAboutUsDto.Description2);
            paramaters.Add("@video",updateAboutUsDto.VideoLink);
            paramaters.Add("@image",updateAboutUsDto.Image);
            using (var connection = _context.CreateConnection())
            {
                 await connection.ExecuteAsync(query, paramaters);
                
            }
        }
    }
}
