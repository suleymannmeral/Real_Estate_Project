﻿using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
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

        public async Task<IActionResult> ServicesList()
        {
            var values = await _productRepository.GetAllProductAsync();
            return Ok(values);
        }




        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var value = await _productRepository.GetProductWithID(id);
            return Ok(value);
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
           await _productRepository.DeleteProduct(id);
            return Ok("Ürün Başarılı Bir Şekilde Sİlindi");
        }
        [HttpPut]

        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
           await _productRepository.UpdateProduct(updateProductDto);
            return Ok("Ürün Başarıyla GÜncellendi");

        }
        [HttpGet("ProductDealOfTheDayChangeToTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayChangeToTrue(int id)
        {
           await _productRepository.ProductDealOfTheDayStatusChangeTrue(id);

            return Ok("ilan durumu  günün fırsatalarına eklendi");

        }
        [HttpGet("ProductDealOfTheDayChangeToFalse/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayChangeToFalse(int id)
        {
           await _productRepository.ProductDealOfTheDayStatusChangeFalse(id);

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



        [HttpGet("getProductByProductID")]
        public async Task<IActionResult> GetProductDetailByProductID(int id)
        {
            var values = await _productRepository.GetProductByProductId(id);
            return Ok(values);
        }

        
        [HttpGet("ResultProductWithSearchList")]
        public async Task<IActionResult> ResultProductWithSearchList(string searchKeyValue,int propertyCategoryId,string city)
        {
            var values = await _productRepository.ResultProductWithSearchList(searchKeyValue,propertyCategoryId,city);
            return Ok(values);
        }


            
        [HttpGet("GetProductByDealOfTheDayTrueCategoryAsync")]
        public async Task<IActionResult> GetProductByDealOfTheDayTrueCategoryAsync()
        {
            var values = await _productRepository.GetProductByDealOfTheDayTrueCategoryAsync();
            return Ok(values);
        }

               
        [HttpGet("ResultLast3ProductWithCategory")]
        public async Task<IActionResult> ResultLast3ProductWithCategoryAsync()
        {
            var values = await _productRepository.GetLast3ProductAsync();
            return Ok(values);
        }
        [HttpGet("GetLastProduct")]

        public async Task<IActionResult> GetLastProduct()
        {
            var values = await _productRepository.GetLastProduct();
            return Ok(values);
        }
        [HttpGet("ProductStatusChangeToTrue/{id}")]
        public async Task<IActionResult> ChangeProductStatusAsActive(int id)
        {
             await _productRepository.ProductChangeAsActive(id);
              return Ok("Product Status Changed Succesfully");
        }
        [HttpGet("ProductStatusAsPassive/{id}")]

        public async Task<IActionResult> ChangeProductStatusAsPassive(int id)
        {
            await _productRepository.ProductStatusChangeAsPassive(id);
            return Ok("Product Status Changed To Passive Succesfuly");
        }






    }
}
