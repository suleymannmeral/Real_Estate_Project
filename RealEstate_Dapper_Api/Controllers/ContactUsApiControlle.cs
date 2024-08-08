using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
