using Dapper;
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

        public Task<ResultAboutUsSectionDto> GetAboutUsSectionByID(int id)
        {
            throw new NotImplementedException();
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

        public Task UpdateAboutUs(UpdateAboutUsSectionDto updateAboutUsSectionDto)
        {
            throw new NotImplementedException();
        }
    }
}
