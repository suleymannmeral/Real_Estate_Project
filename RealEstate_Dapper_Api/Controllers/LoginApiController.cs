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

        public async Task<IActionResult> SignIn(CreateLoginDto loginDto)
        {
            string query = "Select * from Users Where Username=@username and Password=@password";
            string query2 = "Select UserID From Users Where Username=@username and Password=@password";

            var paramaters = new DynamicParameters();
            paramaters.Add("@username", loginDto.Username);
            paramaters.Add("@password", loginDto.Password);
            using (var conenction = _context.CreateConnection())
            {
                var values= await conenction.QueryFirstOrDefaultAsync<CreateLoginDto>(query,paramaters);
                var values2 = await conenction.QueryFirstOrDefaultAsync<GetAppUserDto>(query2,paramaters);

                if (values != null)
                {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                    model.Username = values.Username;
                    model.ID = values2.UserID;
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
             
              
                }
                else
                {
                    return Ok("Başarısız");
                }
            }

        }

    }
}
