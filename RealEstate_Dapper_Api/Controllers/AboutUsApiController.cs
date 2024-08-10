using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.AboutUsDtos;
using RealEstate_Dapper_Api.Repositories.AboutUsRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsApiController : ControllerBase
    {
        private readonly IAboutUsRepository _aboutUsRepository;
        public AboutUsApiController(IAboutUsRepository aboutUsRepository)
        {
            _aboutUsRepository = aboutUsRepository;
        }
        [HttpGet]
        public async Task<IActionResult> AboutUsList()
        {
            var values = await _aboutUsRepository.GetAllAboutUs();
            return Ok(values);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> AboutUsByID(int id)
        {
            var values = await _aboutUsRepository.GetAboutUsByID(id);
            return Ok(values);

        }
        [HttpPut]
        public async Task<IActionResult>UpdateAboutUs(UpdateAboutUsDto updateAboutUs)
        {
            await _aboutUsRepository.UpdateAboutUs(updateAboutUs);
            return Ok("AboutUs Updated SuccsessFully");
        }

    }
}
