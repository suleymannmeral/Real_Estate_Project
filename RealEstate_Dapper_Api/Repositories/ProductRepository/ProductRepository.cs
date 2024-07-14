﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async void CreateProduct(CreateProductDto productDto)
        {

           
                string query = "insert into Product (Title,Price,City,District,ProductCategory) values (@productTitle,@productPrice,@productCity,@productDistrict,@productCategory)";
                var paramaters = new DynamicParameters();
            paramaters.Add("@productTitle", productDto.Title);
            paramaters.Add("@productPrice", productDto.Price);
            paramaters.Add("@productCity", productDto.City);
            paramaters.Add("@productDistrict", productDto.District);
            paramaters.Add("@productCategory", productDto.ProductCategory);

            using (var conenction = _context.CreateConnection())
                {
                    await conenction.ExecuteAsync(query, paramaters);
                }

            
        }

        public async void DeleteProduct(int id)
        {
            string query = ("Delete from Product where ProductID=@productid");
            var paramaters = new DynamicParameters();
            paramaters.Add("@productid", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();

            }


        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName From Product inner join Category on Product.ProductCategory=Category.CategoryID";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();

            }

        }

        public async void UpdateProduct(UpdateProductDto productDto)
        {
            string query = ("Update Product set Title=@ptitle,Price=@pprice,City=@pcity,District=@pDistrict,ProductCategory=@pcatname where ProductID=@pid");
            var paramaters = new DynamicParameters();
            paramaters.Add("@ptitle",productDto.Title);
            paramaters.Add("@pprice", productDto.Price);
            paramaters.Add("@pcity", productDto.City);
            paramaters.Add("@pDistrict", productDto.District);
            paramaters.Add("@pcatname", productDto.ProductCategory);
            paramaters.Add("@pid", productDto.ProductID);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
               
            }





        }
    }
}
