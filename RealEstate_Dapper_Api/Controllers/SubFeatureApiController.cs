using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.SubFeatureRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubFeatureApiController : ControllerBase
    {
        private readonly ISubFeatureRepository _subFeatureRepository;

        public SubFeatureApiController(ISubFeatureRepository subFeatureRepository)
        {
            _subFeatureRepository = subFeatureRepository;
        }

        [HttpGet]
        
        public async Task<IActionResult>GetAllSubFeaturesAsync()
        {
            var values= await _subFeatureRepository.GetSubFeaturesAsync();
            return Ok(values);
        }
    }
}
