using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Dtos.ServicesDto;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
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
            _servicesRepository.CreateServices(createServicesDto);
            return Ok("Servis Başarılı Bİr Şekilde Eklend");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateServices(UpdateServicesDto updateServicesDto)
        {
            _servicesRepository.UpdateServices(updateServicesDto);
            return Ok("Servis Başarıyla GÜncellendi");

        }


    }
}
