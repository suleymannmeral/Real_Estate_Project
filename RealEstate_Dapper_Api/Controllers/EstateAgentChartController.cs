using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashBoardRepositories.ChartRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentChartController : ControllerBase
    {
        private readonly IChartRepositories _chartRepositories;

        public EstateAgentChartController(IChartRepositories chartRepositories)
        {
            _chartRepositories = chartRepositories;
        }
        [HttpGet("Get5CityOfChart")]
        public async Task<IActionResult> ProductCountOrderBYcity()
        {
            var values = await _chartRepositories.Get5CityOfChart();
            return Ok(values);
        }
    }
}
