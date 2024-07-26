using Dapper;
using RealEstate_Dapper_Api.Dtos.MessageDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.MessageRepository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

     
        async Task<List<ResultSendBoxMessageDto>> IMessageRepository.GetLast3MessageByReceiver(int id)
        {
            string query = "Select top(3) * From message where Receiver=@receiverID order by MessageId Desc";
            var paramaters = new DynamicParameters();
            paramaters.Add("@receiverID", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultSendBoxMessageDto>(query,paramaters);
                return values.ToList();

            }
        }
    }
}
