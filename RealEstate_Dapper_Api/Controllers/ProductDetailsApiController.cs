using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Repositories.ProductDetailRepository;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsApiController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductDetailRepository _productDetailRepository;

        public ProductDetailsApiController(IProductRepository productRepository, IProductDetailRepository productDetailRepository)
        {
            _productRepository = productRepository;
            _productDetailRepository = productDetailRepository;
        }

        [HttpGet("getProductDetailByID")]
        public async Task<IActionResult> GetProductDetailByProductID(int id)
        {
            var values = await _productRepository.GetProductDetaByProductId(id);
            return Ok(values);
        }
        [HttpPost("CreateProductDetail")]
        public async Task<IActionResult>CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailRepository.CreateProductDetail(createProductDetailDto);
            return Ok("ProductDetail Başarıyla Eklendi");
        }



    }
}
