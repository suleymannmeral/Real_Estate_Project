using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashBoardRepositories.Last5ProductRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetLast5ProductByEmployeeApiController : ControllerBase
    {
        private readonly ILast5ProductRepository _last5ProductRepository;

        public GetLast5ProductByEmployeeApiController(ILast5ProductRepository last5ProductRepository)
        {
            _last5ProductRepository = last5ProductRepository;
        }
        [HttpGet("GetLast5ProductByEmployeeID")]

        public async Task<IActionResult> GetLast5ProductByEmployeeID(int id)
        {
            var values = await _last5ProductRepository.GetLast5ProductByEmployeeIdAsync(id);
            return Ok(values);
        }
    }
}
