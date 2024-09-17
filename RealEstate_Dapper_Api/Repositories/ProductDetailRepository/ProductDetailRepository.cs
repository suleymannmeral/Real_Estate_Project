using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductDetailRepository
{
    public class ProductDetailRepository : IProductDetailRepository
    {
        private readonly Context _context;

        public ProductDetailRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            string query = "Insert Into ProductDetails (ProductSize,BedRoomCount,BathCount,RoomCount,GarageSize,BuildYear,Price,Location,VideoUrl,ProductID) values (@psize,@bedcount,@bathcount,@roomcount,@garagesize,@buildyear,@price,@location,@videourl,@productid)";
            var paramaters=new DynamicParameters();
            paramaters.Add("@psize", createProductDetailDto.ProductSize);
            paramaters.Add("@bedcount",createProductDetailDto.BedRoomCount);
            paramaters.Add("@bathcount",createProductDetailDto.BathCount);
            paramaters.Add("@roomcount",createProductDetailDto.RoomCount);
            paramaters.Add("@garagesize",createProductDetailDto.GarageSize);
            paramaters.Add("@buildyear",createProductDetailDto.BuildYear);
            paramaters.Add("@price",createProductDetailDto.Price);
            paramaters.Add("@location",createProductDetailDto.Location);
            paramaters.Add("@videourl",createProductDetailDto.VideoUrl);
            paramaters.Add("@productid",createProductDetailDto.ProductID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }

            
        }
    }
}
