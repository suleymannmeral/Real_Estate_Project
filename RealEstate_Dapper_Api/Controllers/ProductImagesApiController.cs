using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.ProductImageRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesApiController : ControllerBase
    {
        private readonly IProductImageRepository _productImageRepository;

        public ProductImagesApiController(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        [HttpGet("GetProductImagesByProductID")]

        public async Task<IActionResult> GetProductImagesByProductID(int id)
        {
            var values=await _productImageRepository.GetProductImageByProductID(id);
            return Ok (values);
        }
    }
}
