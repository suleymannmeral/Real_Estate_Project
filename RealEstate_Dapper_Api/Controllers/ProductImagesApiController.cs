﻿using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductImageDtos;
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
        [HttpPost]

        public async Task<IActionResult>CreateProductImage(int id,CreateProductImageDto createProductImageDto)
        {
            await _productImageRepository.CreateProductImage(id,createProductImageDto);
            return Ok("İmage Added Succesfully");
        }
    }
}
