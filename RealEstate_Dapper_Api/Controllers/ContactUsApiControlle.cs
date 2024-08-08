using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ContactUsDto;
using RealEstate_Dapper_Api.Repositories.AppUserRepositories;
using RealEstate_Dapper_Api.Repositories.ContactRepositories;
using RealEstate_Dapper_Api.Repositories.ContactUsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsApiControlle : ControllerBase
    {
        private readonly  IContactUsRepository contactUsRepository;

        public ContactUsApiControlle(IContactUsRepository contactUsRepository)
        {
            this.contactUsRepository = contactUsRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetContactUsInfo()
        {
            var values = await contactUsRepository.GetContactUsInfo();
            return Ok(values);
        }
        [HttpPut]

        public async Task<IActionResult> UpdateContactUs(UpdateContactUsDto updateContactUsDto)
        {
             await contactUsRepository.UpdateContactUs(updateContactUsDto);
            return Ok("ContactUs BAşarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactUsBYId(int id)
        {
            var value = await contactUsRepository.GetContactUsById(id) ;
            return Ok(value);
        }
    }
}
