using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PopularLocationDto;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepository _popularLocationRepository;
        public PopularLocationsController(IPopularLocationRepository popularLocationRepository)
        {
            _popularLocationRepository = popularLocationRepository;
            
        }

        [HttpGet]

        public async Task<IActionResult> GetPopularLocationList()
        {
            var values = await _popularLocationRepository.GetAllPopularLocationAsync();
            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult>CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            _popularLocationRepository.CreatePopularLocation(createPopularLocationDto);
            return Ok("Ürün Başarılı Bİr Şekilde Eklend");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            _popularLocationRepository.UpdatePopularLocation(updatePopularLocationDto);
            return Ok("Ürün Başarılı Bİr Şekilde Eklend");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletePopularLocation(int id)
        {
            _popularLocationRepository.DeletePopularLocation(id);
            return Ok("locaitın Başarılı Bir Şekilde Sİlindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopularLocationById(int id)
        {
            var value = await _popularLocationRepository.GetPopularLocationById(id);
            return Ok(value);
        }
    }
}
