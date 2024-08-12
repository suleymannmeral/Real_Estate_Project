using Dapper;
using RealEstate_Dapper_Api.Dtos.AboutUsDtos;
using RealEstate_Dapper_Api.Dtos.AboutUsSectionDtos;
using RealEstate_Dapper_Api.Dtos.ContactUsDto;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AboutUsSectionRepository
{
    public class AboutUsSectionRepository : IAboutUsSectionRepository
    {
        private readonly Context _context;

      

        public AboutUsSectionRepository(Context context)
        {
            _context = context;
        }

        public async Task<ResultAboutUsSectionDto> GetAboutUsSectionByID(int id)
        {
            string query = "Select * From AboutUsSection where AboutUsSectionID=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultAboutUsSectionDto>(query,parameters);
                return values;
            }
        }

        public async Task<List<ResultAboutUsSectionDto>> GetAllAboutUsSection()
        {
            string query = "Select * From AboutUsSection";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAboutUsSectionDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateAboutUsSection(UpdateAboutUsSectionDto updateAboutUsSectionDto)
        {
            string query = "Update AboutUsSection Set Icon=@icon,Title=@title,Description=@desc where AboutUsSectionID=@id";
            var paramaters = new DynamicParameters();
            paramaters.Add("@icon", updateAboutUsSectionDto.Icon);
            paramaters.Add("@title", updateAboutUsSectionDto.Title);
            paramaters.Add("@desc", updateAboutUsSectionDto.Description);
  
            paramaters.Add("@id", updateAboutUsSectionDto.AboutUsSectionID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);

            }
        }

    }
}
