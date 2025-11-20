using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using StyleMateAPI.Services;


namespace StyleMate.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly UtilizadorService _users;

        public AuthController(UtilizadorService users)
        {
            _users = users;
        }

        // ============================================================
        // GERAR JWT INTERNO (PARA O MAUI GUARDAR)
        // ============================================================
        private string GenerateJwtToken(string email)
        {
            var key = Environment.GetEnvironmentVariable("JWT_KEY");
            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email)
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(5),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // ============================================================
        // LER CLAIMS (email + nome) DO ID_TOKEN (JWT)
        // ============================================================
        private (string email, string name) ExtractUserInfoFromIdToken(string idToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(idToken);

            var email = jwt.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
            var name = jwt.Claims.FirstOrDefault(c => c.Type == "name")?.Value;

            return (email, name);
        }

        // ============================================================
        // LOGIN MICROSOFT (MOBILE FLOW)
        // ============================================================
        [HttpPost("microsoft-mobile-login")]
        public async Task<IActionResult> MicrosoftMobileLogin([FromBody] MobileAuthDto dto)
        {
            if (string.IsNullOrEmpty(dto.IdToken))
                return BadRequest("ID Token em falta.");

            var (email, name) = ExtractUserInfoFromIdToken(dto.IdToken);

            if (email == null)
                return Unauthorized("ID Token inválido.");

            var user = await _users.CreateOrUpdateExternalAsync(
                email: email,
                externalId: dto.ExternalId,
                nome: name
            );

            var jwt = GenerateJwtToken(email);

            return Ok(new
            {
                provider = "microsoft",
                email,
                token = jwt
            });
        }

        // ============================================================
        // LOGIN GOOGLE (MOBILE FLOW)
        // ============================================================
        [HttpPost("google-mobile-login")]
        public async Task<IActionResult> GoogleMobileLogin([FromBody] MobileAuthDto dto)
        {
            if (string.IsNullOrEmpty(dto.IdToken))
                return BadRequest("ID Token em falta.");

            var (email, name) = ExtractUserInfoFromIdToken(dto.IdToken);

            if (email == null)
                return Unauthorized("ID Token inválido.");

            var user = await _users.CreateOrUpdateExternalAsync(
                email: email,
                externalId: dto.ExternalId,
                nome: name
            );

            var jwt = GenerateJwtToken(email);

            return Ok(new
            {
                provider = "google",
                email,
                token = jwt
            });
        }
    }

    // ============================================================
    // DTO QUE O MAUI ENVIA
    // ============================================================
    public class MobileAuthDto
    {
        public string IdToken { get; set; }
        public string AccessToken { get; set; }
        public string ExternalId { get; set; }
    }
}
