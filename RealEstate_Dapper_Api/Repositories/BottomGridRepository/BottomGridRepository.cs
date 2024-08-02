using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDto;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
    public class BottomGridRepository:IBottomGridRepository
    {
        private readonly Context _context;
        public BottomGridRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            string query = ("insert into BottomGrid (Icon,Title,Description) values (@icon,@title,@desc)");
            var paramaters = new DynamicParameters();
            paramaters.Add("@icon", createBottomGridDto.Icon);
            paramaters.Add("@title", createBottomGridDto.Title);
            paramaters.Add("@desc", createBottomGridDto.Description);

            using (var conenction = _context.CreateConnection())
            {
                await conenction.ExecuteAsync(query, paramaters);   
            }
        }

        public async Task DeleteBottomGrid(int id)
        {
            string query = ("Delete From BottomGrid where BottomGridID=@bgid");
            var paramaters = new  DynamicParameters();
            paramaters.Add("@bgid", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }

        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = ("Select * from BottomGrid");
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDBottomGridDto> GetBottomGridWithID(int id)
        {
            string query = "SELECT * FROM BottomGrid WHERE BottomGridID=@botid";
            var parameters = new DynamicParameters();
            parameters.Add("@botid", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDBottomGridDto>(query, parameters);

                if (values == null)
                {

                    throw new Exception("WhoWeAreDetail not found");

                }

                return values;
            }
        }

        public async Task UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            string query = ("Update BottomGrid set Icon=@icon,Title=@title,Description=@dsc where BottomGridID=@bgid");
            var paramaters= new DynamicParameters();
            paramaters.Add("@icon",updateBottomGridDto.Icon);
            paramaters.Add("@title", updateBottomGridDto.Title);
            paramaters.Add("@dsc", updateBottomGridDto.Description);
            paramaters.Add("@bgid", updateBottomGridDto.BottomGridID);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.ExecuteAsync(query, paramaters);
            }




        }
    }
}
