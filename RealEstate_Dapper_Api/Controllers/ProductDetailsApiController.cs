using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsApiController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductDetailsApiController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("getProductDetailByID")]
        public async Task<IActionResult> GetProductDetailByProductID(int id)
        {
            var values = await _productRepository.GetProductDetaByProductId(id);
            return Ok(values);
        }



    }
}
