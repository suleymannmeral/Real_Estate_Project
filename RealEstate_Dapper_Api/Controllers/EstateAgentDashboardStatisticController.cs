using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashBoardRepositories.StatisticRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentDashboardStatisticController : ControllerBase
    {
        private readonly IStatisticRepository _statisticRepository;

        public EstateAgentDashboardStatisticController(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }
        [HttpGet("ProductCountByEmployeID")]
        public IActionResult ProductCountByEmployeeID(int id)
        {
            var values = _statisticRepository.ProductCountByEmployeeID(id);
            return Ok(values);
        }
        [HttpGet("ProductCountByEmployeIDProductStatusTrue")]
        public IActionResult ProductCountByEmployeIDProductStatusTrue(int id)
        {
            var values = _statisticRepository.ProductCountByStatusTrue(id);
            return Ok(values);
        }
        [HttpGet("ProductCountByEmployeIDProductStatusFalse")]
        public IActionResult ProductCountByEmployeIDProductStatusFalse(int id)
        {
            var values = _statisticRepository.ProductCountByStatusFalse(id);
            return Ok(values);
        }
        [HttpGet("AllProductCount")]
        public IActionResult AllProductCount()
        {
            var values = _statisticRepository.AllProductCount();
            return Ok(values);
        }





    }
}
