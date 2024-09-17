using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductDetailRepository
{
    public interface IProductDetailRepository
    {
        Task CreateProductDetail(CreateProductDetailDto createProductDetailDto);

    }
}
