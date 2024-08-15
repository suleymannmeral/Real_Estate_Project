using RealEstate_Dapper_UI.Enums;

namespace RealEstate_Dapper_UI.Models
{
    public class JwtResponseModel
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
        public RolesType Role { get; set; } // Rol bilgisini ekleyin (isteğe bağlı)
    }
}
