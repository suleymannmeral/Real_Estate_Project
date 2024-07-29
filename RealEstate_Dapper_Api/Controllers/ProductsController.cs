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
    public class ProductsController : ControllerBase
    {
       
            private readonly IProductRepository _productRepository;

            public ProductsController(IProductRepository productRepository)
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
           await _productRepository.CreateProduct(createProductDto);
            return Ok("Ürün Başarılı Bİr Şekilde Eklend");
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
            return Ok("Ürün Başarılı Bir Şekilde Sİlindi");
        }
        [HttpPut]

        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productRepository.UpdateProduct(updateProductDto);
            return Ok("Ürün Başarıyla GÜncellendi");

        }
        [HttpGet("ProductDealOfTheDayChangeToTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayChangeToTrue(int id)
        {
           _productRepository.ProductDealOfTheDayStatusChangeTrue(id);

            return Ok("ilan durumu  günün fırsatalarına eklendi");

        }
        [HttpGet("ProductDealOfTheDayChangeToFalse/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayChangeToFalse(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeFalse(id);

            return Ok("ilan durumu  günü fırsatlarından cıkarıldı");

        }

        [HttpGet("Last5Product")]
        public async Task<IActionResult> GetLast5ProductList()
        {
           var values= await _productRepository.GetLast5ProductAsync();

            return Ok(values);

        }
        [HttpGet("ProductAdvertsListByEmployeeByTrue")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeByTrue(int id)
        {
            var values = await _productRepository.GetProductAdvertListByEmployeeAsyncByTrue(id);
            return Ok(values);
        }
        [HttpGet("ProductAdvertsListByEmployeeByFalse")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeByFalse(int id)
        {
            var values = await _productRepository.GetProductAdvertListByEmployeeAsyncByFalse(id);
            return Ok(values);
        }


       








    }
}
