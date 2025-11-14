using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using StyleMate1._1.Services;

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
        // -----------------------------
        //  GERAR TOKEN JWT
        // -----------------------------
        private string GenerateJwtToken( string email)
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

        // -----------------------------
        //  LOGIN GOOGLE
        // -----------------------------
        [HttpGet("login-google")]
        public IActionResult LoginGoogle()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleCallback")
            };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("google-callback")]
        public async Task<IActionResult> GoogleCallback()
        {
            var result = await HttpContext.AuthenticateAsync();

            if (!result.Succeeded)
                return Unauthorized("Falha no login Google");

            var email = result.Principal.FindFirst(ClaimTypes.Email)?.Value;
            var name = result.Principal.Identity.Name;
            var externalId = result.Principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // ⭐ GRAVA OU ATUALIZA NA BASE DE DADOS
            var user = await _users.CreateOrUpdateExternalAsync(
                email: email,
                externalId: externalId,
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

        // -----------------------------
        //  LOGIN MICROSOFT
        // -----------------------------
        [HttpGet("login-microsoft")]
        public IActionResult LoginMicrosoft()
        {
            var props = new AuthenticationProperties
            {
                RedirectUri = Url.Action("MicrosoftCallback")
            };

            return Challenge(props, MicrosoftAccountDefaults.AuthenticationScheme);
        }

        [HttpGet("microsoft-callback")]
        public async Task<IActionResult> MicrosoftCallback()
        {
            var result = await HttpContext.AuthenticateAsync();

            if (!result.Succeeded)
                return Unauthorized("Falha no login Microsoft");

            var email = result.Principal.FindFirst(ClaimTypes.Email)?.Value;
            var name = result.Principal.Identity.Name;
            var externalId = result.Principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // ⭐ GRAVA OU ATUALIZA NA BASE DE DADOS
            var user = await _users.CreateOrUpdateExternalAsync(
                email: email,
                externalId: externalId,
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
    }
}
