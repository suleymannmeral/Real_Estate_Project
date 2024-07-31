using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {

         Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();

        Task CreateProduct(CreateProductDto productDto);
        Task DeleteProduct(int id);
        Task UpdateProduct(UpdateProductDto productDto);

        Task ProductDealOfTheDayStatusChangeTrue(int id);
        Task ProductDealOfTheDayStatusChangeFalse(int id);
        Task<List<ResultLast5Product>> GetLast5ProductAsync();
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id);
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id);

        Task<GetProductByProductIdDto>GetProductByProductId(int id);
        Task<GetProductDetailByProductID>GetProductDetaByProductId(int id);
        Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue,int propertyCategoryId, string city);
        Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueCategoryAsync();
        Task<List<ResultLast3ProductWithCategoryDto>> GetLast3ProductAsync();








    }
}
