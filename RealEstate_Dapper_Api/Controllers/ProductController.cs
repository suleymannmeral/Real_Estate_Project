using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       
            private readonly IProductRepository _productRepository;

            public ProductController(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            [HttpGet]

            public async Task<IActionResult> ProductList()
            {
                var values = await _productRepository.GetAllProductAsync();
                return Ok(values);
            }

        [HttpGet("ProductListWithCategory")]

        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            _productRepository.CreateProduct(createProductDto);
            return Ok("Ürün Başarılı Bİr Şekilde Eklend");
        }


        [HttpDelete]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
            return Ok("Ürün Başarılı Bir Şekilde Sİlindi");
        }
    }
}
