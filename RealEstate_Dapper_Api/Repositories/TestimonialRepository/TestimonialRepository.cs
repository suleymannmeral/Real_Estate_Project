using Dapper;
using RealEstate_Dapper_Api.Dtos.ServicesDto;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Reflection.Metadata;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepository
{
    public class TestimonialRepository:ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }

        public async void CreateTestimonial(CreateTestimonialDto createstimonialDto)
        {
            var query = ("Insert into Testimonial (NameSurname,Title,Comment,Status) values(@namesurname,@title,@comment,@status)");
            var paramaters = new DynamicParameters();
            paramaters.Add("@namesurname", createstimonialDto.NameSurname);
            paramaters.Add("@title", createstimonialDto.Title);
            paramaters.Add("@comment", createstimonialDto.Comment);
            paramaters.Add("@status", true);


            using (var connection = _context.CreateConnection())
            {
               await connection.ExecuteAsync(query, paramaters);
            }



        }

        public async void DeleteTestimonial(int id)
        {
            string query = ("Delete from Testimonial where TestimonialID=@tmid");
            var paramaters = new DynamicParameters();
            paramaters.Add("@tmid", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,paramaters);
            }
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            string query = "Select * From Testimonial";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                return values.ToList();

            }
        }

        public async void UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            string query = ("Update Testimonial set NameSurname=@namesurname,Title=@title,Comment=@comment,Status=@status where TestimonialID=@tmid");
            var parameters = new DynamicParameters();
            parameters.Add("@namesurname", updateTestimonialDto.NameSurname);
            parameters.Add("@title", updateTestimonialDto.Title);
            parameters.Add("@comment", updateTestimonialDto.Comment);
            parameters.Add("@status", true);
            parameters.Add("@tmid", updateTestimonialDto.TestimonialID);



            using (var connection = _context.CreateConnection())
            {
                var values = await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
