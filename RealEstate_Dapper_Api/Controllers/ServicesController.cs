using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ServicesDto;
using RealEstate_Dapper_Api.Repositories.ServicesRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesRepository _servicesRepository;

        public ServicesController(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }

        [HttpGet]

        public async Task<IActionResult> ServicesList()
        {
            var values = await _servicesRepository.GetServicesAsync();
            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateServices(CreateServicesDto createServicesDto)
        {
           await _servicesRepository.CreateServices(createServicesDto);
            return Ok("Servis Başarılı Bİr Şekilde Eklend");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateServices(UpdateServicesDto updateServicesDto)
        {
          await  _servicesRepository.UpdateServices(updateServicesDto);
            return Ok("Servis Başarıyla GÜncellendi");

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
           await _servicesRepository.DeleteServices(id);
            return Ok("Detail Başarılı Bİr Şekilde Silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiseById(int id)
        {
            var value = await _servicesRepository.GetServicesWithID(id);
            return Ok(value);
        }



    }
}
