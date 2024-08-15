using Dapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.LoginDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginApiController : ControllerBase
    {

        private readonly Context _context;

        public LoginApiController(Context context)
        {
            _context = context;
        }

        [HttpPost]

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto loginDto)
        {
            string query = "SELECT * FROM Users WHERE Username=@username AND Password=@password";
            string query2 = "SELECT UserID, UserRole FROM Users WHERE Username=@username AND Password=@password";

            var parameters = new DynamicParameters();
            parameters.Add("@username", loginDto.Username);
            parameters.Add("@password", loginDto.Password);

            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query, parameters);
                var userDetails = await connection.QueryFirstOrDefaultAsync<GetAppUserDto>(query2, parameters);

                if (user != null)
                {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel
                    {
                        Username = user.Username,
                        ID = userDetails.UserID,
                        RoleID = userDetails.UserRole // UserRole ID'sini al
                    };

                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized("Başarısız");
                }
            }
        }


    }
}
