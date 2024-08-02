using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDto;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Reflection.Metadata;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreRepository:IWhoWeAreRepository
    {
        private readonly Context _context;



       

        public WhoWeAreRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateWhoWeAre(CreateWhoWeAreDto whoWeAreDto)
        {
            string query = ("Insert Into WhoWeAreDetail (Title,Subtitle,Description1,Description2) values (@Title,@Subtitle,@Description1,@Description2)");
            var parameters = new DynamicParameters();
            parameters.Add("@Title",whoWeAreDto.Title);
            parameters.Add("@Subtitle", whoWeAreDto.Subtitle);
            parameters.Add("@Description1", whoWeAreDto.Description1);
            parameters.Add("@Description2", whoWeAreDto.Description2);
            using (var conenction = _context.CreateConnection())
            {
              await conenction.ExecuteAsync(query,parameters);
            }


        }

        public async Task DeleteWhoWeAre(int id)
        {
            string query = ("Delete From WhoWeAreDetail where WhoWeAreDetailID=@whoweareid");
            var parameters = new DynamicParameters();
            parameters.Add("@whoweareid", id);
            using (var conenction = _context.CreateConnection())
            {
                await conenction.ExecuteAsync(query,parameters);
            }




        }

        public async Task<List<ResultWhoWeAreDto>> GetAllWhoWeAreAsync()
        {
            string query = "Select * From WhoWeAreDetail";

            using (var connection = _context.CreateConnection())
            {
                var values =await connection.QueryAsync<ResultWhoWeAreDto>(query);
                return values.ToList();

            }

        }

        public async Task<GetByIDWhoWeAreDto> GetWhoWeAre(int id)
        {
            string query = "SELECT * FROM WhoWeAreDetail WHERE WhoWeAreDetailID=@wwaid";
            var parameters = new DynamicParameters();
            parameters.Add("@wwaid", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDto>(query, parameters);

                if (values == null)
                {
                    
                    throw new Exception("WhoWeAreDetail not found");
                   
                }

                return values;
            }
        }

        public async Task UpdateWhoWeAre(UpdateWhoWeAreDto whoWeAreDto)
        {
            string query = ("Update WhoWeAreDetail set Title=@title,Subtitle=@subtitle,Description1=@description1,Description2=@description2 where WhoWeAreDetailID=@whoweareid");
            var paramaters=new DynamicParameters();
            paramaters.Add("@title", whoWeAreDto.Title);
            paramaters.Add("@subtitle", whoWeAreDto.Subtitle);
            paramaters.Add("@description1", whoWeAreDto.Description1);
            paramaters.Add("description2",whoWeAreDto.Description2);
            paramaters.Add("whoweareid",whoWeAreDto.WhoWeAreDetailID);
            using(var conenction = _context.CreateConnection())
            {
                var values= await conenction.ExecuteAsync(query,paramaters);

            }


        }
    }
}
