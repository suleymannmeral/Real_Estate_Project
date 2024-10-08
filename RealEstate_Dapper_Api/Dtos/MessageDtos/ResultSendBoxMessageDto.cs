﻿namespace RealEstate_Dapper_Api.Dtos.MessageDtos
{
    public class ResultSendBoxMessageDto
    {
        public int MessageID { get; set; }
        public string  Name{ get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public string UserImageUrl { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
