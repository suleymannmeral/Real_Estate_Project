using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.MessageRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }


        // const olusturduk

        [HttpGet("ResultLast3MessagesByReceiverID")]

        public async Task<IActionResult> GetLast3Messages(int id)
        {
            var values = await _messageRepository.GetLast3MessageByReceiver(id);
            return Ok(values);
        }
    }
}
