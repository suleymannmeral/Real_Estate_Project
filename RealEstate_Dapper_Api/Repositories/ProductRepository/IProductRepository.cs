﻿using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {

         Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();

        void CreateProduct(CreateProductDto productDto);
        void DeleteProduct(int id);




    }
}
