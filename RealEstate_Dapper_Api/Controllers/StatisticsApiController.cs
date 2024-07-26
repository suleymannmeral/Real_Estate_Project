using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;
using RealEstate_Dapper_Api.Repositories.StatisticsApiRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IStatisticsApiRepository _statisticRepository;
        public StatisticsApiController(IStatisticsApiRepository statisticsApiRepository)
        {
            _statisticRepository = statisticsApiRepository;
        }
        [HttpGet]
        public  IActionResult ActiveCategoryCount()
        {
            var values = _statisticRepository.ActiveCategoryCount();
            return Ok(values);
        }
        [HttpGet("Activeemployee")]
        public IActionResult ActiveEmployeeCount()
        {
            var values = _statisticRepository.ActiveEmployeeCount();
            return Ok(values);
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var values = _statisticRepository.ProductCount();
            return Ok(values);
        }
        [HttpGet("ApartmentCount")]
        public IActionResult ApartmentCount()
        {
            var values = _statisticRepository.ApartmentCount();
            return Ok(values);
        }
        [HttpGet("RentProductAvgPrice")]
        public IActionResult RentProductPrice()
        {
            var values = _statisticRepository.AvgProductByRent();
            return Ok(values);
        }
        [HttpGet("SaleProductAvgPrice")]
        public IActionResult SaleProductPrice()
        {
            var values = _statisticRepository.AvgProductBySale();
            return Ok(values);
        }
        [HttpGet("AvgRoomCount")]
        public IActionResult RoomCount()
        {
            var values = _statisticRepository.AvgRoomCount();
            return Ok(values);
        }
        [HttpGet("AvgCategoryCount")]
        public IActionResult Category()
        {
            var values = _statisticRepository.CategoryCount();
            return Ok(values);
        }
        [HttpGet("CategoryNameByMaxProduct")]
        public IActionResult CategoryNameByMaxProduct()
        {
            var values = _statisticRepository.CategoryNameByMaxProduct();
            return Ok(values);
        }

        [HttpGet("CityNameByMaxProduct")]
        public IActionResult CityNameByMaxProduct()
        {
            var values = _statisticRepository.CityNameByMaxProduct();
            return Ok(values);
        }
        [HttpGet("DifferentCityCount")]
        public IActionResult DifferentCityCount()
        {
            var values = _statisticRepository.DifferentCityCount();
            return Ok(values);
        }

        [HttpGet("EmployeeNameByMaxProduct")]
        public IActionResult EmployeeNameByMaxProduct()
        {
            var values = _statisticRepository.EmployeeNameByMaxProduct();
            return Ok(values);
        }
        [HttpGet("LastProductPrice")]
        public IActionResult LastProductPrice()
        {
            var values = _statisticRepository.LastProductPrice();
            return Ok(values);
        }
        [HttpGet("OldestBuildingYear")]
        public IActionResult OldestBuildingYear()
        {
            var values = _statisticRepository.OldestBuildingYear();
            return Ok(values);
        }
        [HttpGet("NewestBuildingYear")]
        public IActionResult NewestBuildingYear()
        {
            var values = _statisticRepository.NewestBuildingYear();
            return Ok(values);
        }

        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            var values = _statisticRepository.PassiveCategoryCount();
            return Ok(values);
        }







    }
}
