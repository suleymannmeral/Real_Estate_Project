using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using Dapper;
using System.Reflection.Metadata;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{

    public class CategoryRepository : ICategoryRepository
    {

        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async  void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = ("insert into Category (CategoryName,CategoryStatus) values (@categoryName,@categoryStatus)");
            var paramaters = new DynamicParameters();
            paramaters.Add("@categoryName",categoryDto.CategoryName);
            paramaters.Add("@categoryStatus",true);
            using (var conenction = _context.CreateConnection())
            {
                await conenction.ExecuteAsync(query, paramaters);
            }

        }

        public async Task DeleteCategory(int id)
        {

            string query = "Delete From Category Where CategoryID=@categoryID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@categoryID", id);
          
            using (var conenction = _context.CreateConnection())
            {
                await conenction.ExecuteAsync(query,paramaters);
            }


        }

        public async  Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();

            }

        }

        public async Task<GetByIDCategoryDto> GetCAtegory(int id)
        {
            string query = "Select * From Category where CategoryID=@categoryID";
            var parameters = new DynamicParameters();

            parameters.Add("@CategoryID", id);
            using (var conn = _context.CreateConnection())
            {
               var values= await conn.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query,parameters);
                return values;
            }



        }

        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "Update Category set CategoryName=@categoryName,CategoryStatus=@categoryStatus where CategoryID=@categoryID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@categoryName", categoryDto.CategoryName);
            paramaters.Add("@categoryStatus", categoryDto.CategoryStatus);
            paramaters.Add("@categoryID", categoryDto.CategoryId);

            using (var conenction = _context.CreateConnection())
            {
                await conenction.ExecuteAsync(query, paramaters);
            }

        }
    }
}
