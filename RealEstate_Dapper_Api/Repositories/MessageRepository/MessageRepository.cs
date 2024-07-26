using RealEstate_Dapper_Api.Dtos.MessageDtos;

namespace RealEstate_Dapper_Api.Repositories.MessageRepository
{
    public class MessageRepository : IMessageRepository
    {
        public Task<ResultSendBoxMessageDto> GetLast3MessageByReceiver(int id)
        {
            throw new NotImplementedException();
        }
    }
}
