using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StockTrackingAPI.JWT;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StockTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Yönetici,Kullanici")]
    public class AuthenticationController : ControllerBase
    {
        private readonly JWTSettings _jwtSettings;

        public AuthenticationController(IOptions<JWTSettings> jwtsettings)
        {
            _jwtSettings = jwtsettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("Giris")]
        public IActionResult Giris([FromBody] APIUser aPIUser)
        {
            var apiuser = KimlikDenetimiYap(aPIUser);
            if (apiuser == null) return NotFound("Kullanıcı Bulunamadı");

            var token = TokenOlustur(aPIUser);
            return Ok(token);
        }

        private string TokenOlustur(APIUser aPIUser1)
        {
            if (_jwtSettings.Key == null) throw new Exception("JWT ayarlarındaki Key değeri null olamaz");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claim = new[]
            {
                new Claim(ClaimTypes.Role,aPIUser1.Rol!)
            };

            var token = new JwtSecurityToken(_jwtSettings.Issuer,
                _jwtSettings.Audience,
                claim,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private APIUser? KimlikDenetimiYap(APIUser aPIUser)
        {
            return APIUserList
                .Users
                .FirstOrDefault(x => x.KullaniciAdi?.ToLower() == aPIUser.KullaniciAdi
                && x.Sifre == aPIUser.Sifre
                );
        }
    }
}
