using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
