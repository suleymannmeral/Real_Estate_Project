using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDto;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.TestimonialRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {

        private readonly ITestimonialRepository _testimonialrepository;

        public TestimonialController(ITestimonialRepository testimonialRepository)
        {
            _testimonialrepository = testimonialRepository;
        }
        [HttpGet]

        public async Task<IActionResult>GetTestimonialList()
        {
            var values= await _testimonialrepository.GetAllTestimonialAsync();
            return Ok(values);

        }


        [HttpPost]

        public async Task<IActionResult> CreateWhoWeAre(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialrepository.CreateTestimonial(createTestimonialDto);
            return Ok("Testimonial Başarılı Bİr Şekilde Eklend");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            _testimonialrepository.DeleteTestimonial(id);
            return Ok("Testimonial Başarılı Bİr Şekilde Silindi");
        }
        [HttpPut]

        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialrepository.UpdateTestimonial(updateTestimonialDto);
            return Ok("Güncelleme Başarılı");

        }

    }
}
