using Dapper;
using RealEstate_Dapper_Api.Dtos.PropertyAmenityDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepository
{
    public class PropertyAmenityRepository : IPropertyAmenityRepository
    {
        private readonly Context _context;

        public PropertyAmenityRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPropertyAmenityByStatusTrue>> GetPropertyAmenityByStatusTrue(int id)
        {
            string query = "Select PropertyAmenityId,Title From PropertyAmenity Inner Join Amenity On Amenity.AmenityID=PropertyAmenity.AmenityId Where PropertyID=@propertyId And Status=1";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyAmenityByStatusTrue>(query, parameters);
                return values.ToList();
            }
        }
    }
}
