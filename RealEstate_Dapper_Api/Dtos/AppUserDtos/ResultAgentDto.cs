namespace RealEstate_Dapper_Api.Dtos.AppUserDtos
{
    public class ResultAgentDto
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int UserRole { get; set; }
        public string UserImageUrl { get; set; }
    }
}
