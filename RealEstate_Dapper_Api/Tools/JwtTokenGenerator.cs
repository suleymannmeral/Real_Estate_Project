using Microsoft.IdentityModel.Tokens;
using RealEstate_Dapper_Api.Tools;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtTokenGenerator
{
    public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
    {
        var claims = new List<Claim>();

        // Rol bilgisini string olarak ekliyoruz
        claims.Add(new Claim(ClaimTypes.Role, model.RoleID.ToString()));

        claims.Add(new Claim(ClaimTypes.NameIdentifier, model.ID.ToString()));

        if (!string.IsNullOrWhiteSpace(model.Username))
            claims.Add(new Claim("Username", model.Username));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
        var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);
        JwtSecurityToken token = new JwtSecurityToken(
            issuer: JwtTokenDefaults.ValidUssuer,
            audience: JwtTokenDefaults.ValidUssuer,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expireDate,
            signingCredentials: signinCredentials);

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        return new TokenResponseViewModel(tokenHandler.WriteToken(token), expireDate);
    }
}
