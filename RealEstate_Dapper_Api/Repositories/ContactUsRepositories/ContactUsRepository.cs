using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactUsDto;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactUsRepositories
{
    public class ContactUsRepository : IContactUsRepository

    {
        private readonly Context _context;
        public ContactUsRepository(Context context)
        {
            _context = context;
        }
        public async  Task<List<ResultContactUsDto>> GetContactUsInfo()
        {
            string query = "Select * From ContactUs";
            using (var connection = _context.CreateConnection())
            {
                var values =  await connection.QueryAsync<ResultContactUsDto>(query);
                return values.ToList();
            }

        }
    }
}
