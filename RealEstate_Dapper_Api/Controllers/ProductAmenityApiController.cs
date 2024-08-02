using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.PropertyAmenityRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAmenityApiController : ControllerBase
    {
        private readonly IPropertyAmenityRepository _propertyAmenityRepository;

        public ProductAmenityApiController(IPropertyAmenityRepository propertyAmenityRepository)
        {
            _propertyAmenityRepository = propertyAmenityRepository;
        }

        [HttpGet("getPropertyAmenityByStatusTrue")]
        public async Task<IActionResult> GetProductDetailByProductID(int id)
        {
            var values = await _propertyAmenityRepository.GetPropertyAmenityByStatusTrue(id);
            return Ok(values);
        }
    }
}
