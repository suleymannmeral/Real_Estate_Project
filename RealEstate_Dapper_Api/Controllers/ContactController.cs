using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.BottomGridRepository;
using RealEstate_Dapper_Api.Repositories.ContactRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;


        // const olusturduk
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        [HttpGet("ResultLast4Contact")]

        public async Task<IActionResult> GetLast4Contact()
        {
            var values = await _contactRepository.GetAllLast4Contact();
            return Ok(values);
        }

    }
}
