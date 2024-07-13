using Dapper;
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
    }
}
