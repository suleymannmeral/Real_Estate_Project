using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.AboutUsDtos;
using RealEstate_Dapper_Api.Dtos.AboutUsSectionDtos;
using RealEstate_Dapper_Api.Repositories.AboutUsSectionRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsSectionApiController : ControllerBase
    {
        private readonly IAboutUsSectionRepository _aboutUsSectionRepository;

        public AboutUsSectionApiController(IAboutUsSectionRepository aboutUsSectionRepository)
        {
            _aboutUsSectionRepository = aboutUsSectionRepository;
        }
        [HttpGet]

        public async Task<IActionResult> GetAboutUsSection()
        {
            var values = await _aboutUsSectionRepository.GetAllAboutUsSection();
            return Ok(values);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> AboutUsSectionByID(int id)
        {
            var values = await _aboutUsSectionRepository.GetAboutUsSectionByID(id);
            return Ok(values);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateAboutUsSection(UpdateAboutUsSectionDto updateAboutUs)
        {
            await _aboutUsSectionRepository.UpdateAboutUsSection(updateAboutUs);
            return Ok("AboutUsSection Updated SuccsessFully");
        }
    }
}
