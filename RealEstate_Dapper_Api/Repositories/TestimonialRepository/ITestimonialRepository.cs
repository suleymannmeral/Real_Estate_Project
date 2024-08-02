using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDto;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepository
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();

        Task CreateTestimonial(CreateTestimonialDto createstimonialDto);
        Task DeleteTestimonial(int id);

        Task UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto);

        



    }
}
