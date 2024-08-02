using Dapper;
using RealEstate_Dapper_Api.Dtos.ServicesDto;
using RealEstate_Dapper_Api.Dtos.ToDoListDto;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepository
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateToDoList(CreateToDoListDto createToDoListDto)
        {
            var query = ("Insert into ToDoList (Description,ToDoListStatus) values(@desc,@todoliststatus)");
            var paramaters = new DynamicParameters();
            paramaters.Add("@desc", createToDoListDto.Description);
            paramaters.Add("@todoliststatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }

        }

        public async Task DeleteToDoList(int id)
        {
            string query = ("Delete from ToDoList where ToDoListID=@todolistID");
            var paramaters = new DynamicParameters();
            paramaters.Add("@todolistID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,paramaters);
            }
        }

        public async Task<List<ResultToDoListDto>> GetToDoListAsync()
        {
            string query = "Select * From ToDoList";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDto>(query);
                return values.ToList();

            }
        }

        public async Task<GetByIDToDoListDto> GetToDoListByID(int id)
        {
            string query = "SELECT * FROM ToDoList where ToDoListID=@todolistID";
            var parameters = new DynamicParameters();
            parameters.Add("@todolistID", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDToDoListDto>(query);

                if (values == null)
                {

                    throw new Exception("ToDoList not found");

                }

                return values;
            }
        }

        public async Task UpdateServices(UpdateToDoListDto updateToDoListDto)
        {
            string query = ("Update ToDoList set Description=@desc,ToDoListStatus=@todolistStatus where ToDoListID=@todolistID");
            var parameters = new DynamicParameters();
            parameters.Add("@desc", updateToDoListDto.Description);
            parameters.Add("@todolistStatus", updateToDoListDto.ToDoListStatus);
            parameters.Add("@todolistID", updateToDoListDto.ToDoListID);


            using (var connection = _context.CreateConnection())
            {
                var values = await connection.ExecuteAsync(query,parameters);
            }
        }
    }
}
