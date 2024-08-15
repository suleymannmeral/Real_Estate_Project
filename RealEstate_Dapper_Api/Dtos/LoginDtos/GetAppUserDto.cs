using RealEstate_Dapper_Api.Enums;

namespace RealEstate_Dapper_Api.Dtos.LoginDtos
{
    public class GetAppUserDto
    {
        
            public int UserID { get; set; }
            public string Username { get; set; }
        public int UserRole { get; set; } // Rol ID'sini tutmak için



    }
}
