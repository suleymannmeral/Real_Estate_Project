using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Dtos.ProductImageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductImageRepositories
{
    public class ProductImageRepository:IProductImageRepository
    {
        private readonly Context _context;

        public ProductImageRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateProductImage(int id, CreateProductImageDto createProductImageDto)
        {
            string query = "Insert into ProductImage (ImageUrl,ProductID) values (@imageurl,@productID)";
            var parameters = new DynamicParameters();
            parameters.Add("imageurl", createProductImageDto.ImageUrl);
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }

        public async Task<List<ProductImageByProductIDDto>> GetProductImageByProductID(int id)
        {

            string query = "Select * from ProductImage where ProductID=@productid ";
            var parameters = new DynamicParameters();
            parameters.Add("@productid", id);
            using (var connection = _context.CreateConnection())
            {

                var values = await connection.QueryAsync<ProductImageByProductIDDto>(query,parameters);
                if (values != null)
                {
                    return values.ToList();
                }
                else
                {
                    throw new Exception("Product Not Found");
                }
              

            }

        }

      
    }
}
