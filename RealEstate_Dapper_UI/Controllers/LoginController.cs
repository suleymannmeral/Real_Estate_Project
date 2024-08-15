using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Dtos.LoginDtos;
using RealEstate_Dapper_UI.Enums;
using System.Security.Claims;
using System.Text.Json;
using System.Text;
using RealEstate_Dapper_UI.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace RealEstate_Dapper_UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(createLoginDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44382/api/LoginApi", content);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();

                    if (tokenModel.Token != null)
                    {
                        claims.Add(new Claim("realestatetoken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);

                        // Token'dan rol bilgisini al
                        var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                        if (roleClaim != null && int.TryParse(roleClaim, out var userRole))
                        {
                            // UserRole değerine göre yönlendirme yap
                            switch (userRole)
                            {
                                case 1:
                                    return RedirectToAction("Index", "DashBoard");
                                case 2:
                                    return RedirectToAction("MemberDashboard", "Member");
                                case 3:
                                    return RedirectToAction("VisitorDashboard", "Visitor");
                                case 4:
                                    return RedirectToAction("ManagerDashboard", "Manager");
                                case 5:
                                    return RedirectToAction("EstateAgentDashboard", "EstateAgent");
                                default:
                                    return RedirectToAction("Index", "Home"); // Varsayılan yönlendirme
                            }
                        }

                        // Eğer rol bilgisi alınamazsa varsayılan yönlendirme
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            // Başarısız giriş durumunda yeniden login sayfasını göster
            ViewBag.ErrorMessage = "Giriş başarısız. Kullanıcı adı veya şifre yanlış.";
            return View();
        }
    }
}
