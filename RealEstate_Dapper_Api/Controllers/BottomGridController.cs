using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Repositories.BottomGridRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridController : ControllerBase
    {
        private readonly IBottomGridRepository _bottomGridRepository;


        // const olusturduk
        public BottomGridController(IBottomGridRepository bottomGridRepository)
        {
            _bottomGridRepository = bottomGridRepository;
        }

        [HttpGet]

        public async Task<IActionResult> BottomGridList()
        {
            var values = await _bottomGridRepository.GetAllBottomGridAsync();
            return Ok(values);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBottomGrid(int id)
        {
           await _bottomGridRepository.DeleteBottomGrid(id);
            return Ok("Bottom Grid Deleted Successfuly");
        }

        [HttpPut]
        public async Task<IActionResult>UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
           await _bottomGridRepository.UpdateBottomGrid(updateBottomGridDto);
            return Ok("Bottomgrid Güncelleme Başarılı");
        }
        [HttpPost]
        public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
           await _bottomGridRepository.CreateBottomGrid(createBottomGridDto);
            return Ok("Bottomgrid Ekleme Başarılı");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetBottomGridWithID(int id)
        {
            var values = await _bottomGridRepository.GetBottomGridWithID(id);
            return Ok(values);
        }
    }
}
