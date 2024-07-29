using RealEstate_Dapper_Api.Dtos.PropertyAmenityDtos;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepository
{
    public interface IPropertyAmenityRepository
    {
        Task<List<ResultPropertyAmenityByStatusTrue>> GetPropertyAmenityByStatusTrue(int id);
    }
}
