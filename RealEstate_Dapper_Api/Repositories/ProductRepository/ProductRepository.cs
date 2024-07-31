using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
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

        public async Task CreateProduct(CreateProductDto productDto)
        {

           
                string query = "insert into Product (Title,Price,City,District,CoverImage,Adress,Description,Type,DealOfTheDay,advertDate,ProductStatus,ProductCategory,EmployeeID) values (@productTitle,@productPrice,@productCity,@productDistrict,@coverimage,@adress,@desc,@type,@dealoftheday,@advertdate,@productstatus,@productcategory,@employeid)";
                var paramaters = new DynamicParameters();
            paramaters.Add("@productTitle", productDto.Title);
            paramaters.Add("@productPrice", productDto.Price);
            paramaters.Add("@productCity", productDto.City);
            paramaters.Add("@productDistrict", productDto.District);
            paramaters.Add("@coverimage", productDto.CoverImage);
            paramaters.Add("@adress", productDto.Adress);
            paramaters.Add("@desc", productDto.Description);
            paramaters.Add("@type", productDto.Type);
            paramaters.Add("@dealoftheday", productDto.DealOfTheDay);
            paramaters.Add("@advertdate", productDto.advertDate);
            paramaters.Add("@productstatus", productDto.ProductStatus);
            paramaters.Add("@productcategory", productDto.ProductCategory);
            paramaters.Add("@employeid", productDto.EmployeeID);

            using (var conenction = _context.CreateConnection())
                {
                    await conenction.ExecuteAsync(query, paramaters);
                }

            
        }

        public async Task DeleteProduct(int id)
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
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Adress,Type,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();

            }

        }

        public async Task<List<ResultLast3ProductWithCategoryDto>> GetLast3ProductAsync()
        {


            string query = "Select Top(3) ProductID,Title,Price,City,District,ProductCategory,CategoryName,advertDate,CoverImage,Description From Product Inner Join Category On Product.ProductCategory=Category.CategoryID  Order By ProductID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast3ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5Product>> GetLast5ProductAsync()
        {
            string query = "Select Top(5) ProductID,Title,Price,City,District,ProductCategory,CategoryName,advertDate From Product Inner Join Category On Product.ProductCategory=Category.CategoryID Where Type='Rent' Order By ProductID Desc";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5Product>(query);
                return values.ToList();

            }

        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id)
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Adress,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID where EmployeeID=@employeeId and ProductStatus=0  ";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id)
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Adress,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID where EmployeeID=@employeeId and ProductStatus=1  ";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query,parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueCategoryAsync()
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Adress,Type,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID where DealOfTheDay=1";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();

            }
        }

        public async Task<GetProductByProductIdDto> GetProductByProductId(int id)
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Adress,Type,DealOfTheDay,advertDate,Description From Product inner join Category on Product.ProductCategory=Category.CategoryID where ProductID=@productid";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {

                var values = await connection.QueryAsync<GetProductByProductIdDto>(query, parameters);
                return values.FirstOrDefault();

            }


        }

        public async Task<GetProductDetailByProductID> GetProductDetaByProductId(int id)
        {
            string query = "Select * From ProductDetails where ProductID=@productid";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {

                var values = await connection.QueryAsync<GetProductDetailByProductID>(query, parameters);
                return values.FirstOrDefault();

            }


        }

        public async Task ProductDealOfTheDayStatusChangeFalse(int id)
        {
            string query = "Update Product Set DealOfTheDay=0 where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
               await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task ProductDealOfTheDayStatusChangeTrue(int id)
        {
            string query = "Update Product Set DealOfTheDay=1 where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
               await connection.ExecuteAsync(query, parameters);    
            }
        }

        public async Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            string query = "Select * from Product where Title like '%"+ searchKeyValue+"%' and ProductCategory=@propertyCategoryID and City=@city";
            var parameters = new DynamicParameters();
            //parameters.Add("@searchKeyValue", searchKeyValue);
            parameters.Add("@propertyCategoryID", propertyCategoryId);
            parameters.Add("@city", city);
            using (var connection = _context.CreateConnection())
            {

                var values = await connection.QueryAsync<ResultProductWithSearchListDto>(query, parameters);
                return values.ToList();

            }
        }

        public async Task UpdateProduct(UpdateProductDto productDto)
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
