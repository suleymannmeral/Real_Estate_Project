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

        public async Task<ResultContactUsDto> GetContactUsById(int id)
        {
            string query = "Select * From ContactUs where ContactUsID=@id";
            var parameters = new DynamicParameters();

            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultContactUsDto>(query, parameters);
                return values;
            }
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

        public async Task UpdateContactUs(UpdateContactUsDto updateContactUs)
        {
            string query = "Update ContactUs set OfficeAdress=@officeadress,Phone=@phone,Email=@email,Tel=@tel,Location=@location where ContactUsID=@id";
            var parametes = new DynamicParameters();
            parametes.Add("@officeadress",updateContactUs.OfficeAdress);
            parametes.Add("@phone",updateContactUs.Phone);
            parametes.Add("@email",updateContactUs.Email);
            parametes.Add("@tel",updateContactUs.Tel);
            parametes.Add("@location",updateContactUs.Location);
            parametes.Add("@id",updateContactUs.ContactUsId);
            using (var connection = _context.CreateConnection())
            {
                var values=await connection.ExecuteAsync(query,parametes);

            }



        }
    }
}
