using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.AppUserRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserApiController : ControllerBase
    {
        private readonly IAppUserRepository _appuserRepository;

        public AppUserApiController(IAppUserRepository appuserRepository)
        {
            _appuserRepository = appuserRepository;
        } 
        [HttpGet]
        public async Task<IActionResult> GetAppUserByProductID(int id)
        {
            var values = await _appuserRepository.GetAppUserByProductID(id);
            return Ok(values);

        }

    }
}
