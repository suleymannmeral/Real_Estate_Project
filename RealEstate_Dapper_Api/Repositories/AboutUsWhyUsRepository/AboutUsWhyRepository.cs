using Dapper;
using RealEstate_Dapper_Api.Dtos.AboutUsSectionDtos;
using RealEstate_Dapper_Api.Dtos.AboutUsWhyUsDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AboutUsWhyUsRepository
{
    public class AboutUsWhyRepository : IAboutUsWhyUsRepository
    {
        private readonly Context _context;

        public AboutUsWhyRepository(Context context)
        {
            _context = context;
        }

        public async Task<ResultAboutUsWhyUsDto> GetAboutUsWhyUsById(int id)
        {

            string query = "Select * From WhyUs where WhyUsId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultAboutUsWhyUsDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultAboutUsWhyUsDto>> GetAllAboutUsWhyUs()
        {
            string query = "Select * From WhyUs";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAboutUsWhyUsDto>(query);
                return values.ToList();
            }

            
        }

        public async Task UpdateAboutUsWhyUs(UpdateAboutUsWhyUsDto updateAboutUsWhyUsDto)
        {
            string query = "Update WhyUs Set Title=@title,Description=@desc,s1=@s1 ,s2=@s2 ,s3=@s3 ,s4=@s4  where WhyUsId=@id";
            var paramaters = new DynamicParameters();
            paramaters.Add("@title",updateAboutUsWhyUsDto.Title );
            paramaters.Add("@desc", updateAboutUsWhyUsDto.Description);
            paramaters.Add("@s1", updateAboutUsWhyUsDto.s1);
            paramaters.Add("@s2", updateAboutUsWhyUsDto.s2);
            paramaters.Add("@s3", updateAboutUsWhyUsDto.s3);
            paramaters.Add("@s4", updateAboutUsWhyUsDto.s4);
            paramaters.Add("@id", updateAboutUsWhyUsDto.WhyUsId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);

            }
        }
    }
}
