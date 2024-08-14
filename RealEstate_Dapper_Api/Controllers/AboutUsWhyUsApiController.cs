using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.AboutUsWhyUsDtos;
using RealEstate_Dapper_Api.Repositories.AboutUsWhyUsRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsWhyUsApiController : ControllerBase
    {
        private readonly IAboutUsWhyUsRepository _aboutUsWhyUsRepository;

        public AboutUsWhyUsApiController(IAboutUsWhyUsRepository aboutUsWhyUsRepository)
        {
            _aboutUsWhyUsRepository = aboutUsWhyUsRepository;
        }

        [HttpGet]
        public async Task<IActionResult>GetAllWhyUs()
        {
            var values = await _aboutUsWhyUsRepository.GetAllAboutUsWhyUs();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetAllWhyUsById(int id)
        {
            var values = await _aboutUsWhyUsRepository.GetAboutUsWhyUsById(id);
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWhyUs(UpdateAboutUsWhyUsDto updateAboutUsWhyUsDto)
        {
            await _aboutUsWhyUsRepository.UpdateAboutUsWhyUs(updateAboutUsWhyUsDto);
            return Ok("Update Successfully");

        }

    }


}
