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
        [HttpGet("AgentList")]
        public async Task<IActionResult> GetAgent()
        {
            var values = await _appuserRepository.GetAgentByUserRole();
            return Ok(values);

        }
        [HttpGet("AppUSer{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var values = await _appuserRepository.GetAppUserByUserID(id);
            return Ok(values);

        }

    }
}
