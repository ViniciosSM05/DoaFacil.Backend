using DoaFacil.Backend.Infra.Authentication.AuthModels.Token;
using DoaFacil.Backend.Infra.Configuration.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DoaFacil.Backend.Infra.Authentication.AuthServices.Token
{
    public class TokenAuthService(IAuthConfig authConfig) : ITokenAuthService
    {
        public TokenAuthModel GenerateToken(GenerateTokenAuthModel generateModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(authConfig.TokenEncryptKey);

            var expiresIn = DateTime.UtcNow.AddHours(authConfig.TempoDeValidadeDoTokenEmHoras);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new(ClaimTypes.NameIdentifier, generateModel.UserId.ToString()),
                    new(ClaimTypes.Name, generateModel.UserName),
                    new(ClaimTypes.Email, generateModel.UserEmail),
                    new(ClaimTypes.Role, generateModel.UserRole),
                ]),
                Expires = expiresIn,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string strToken = tokenHandler.WriteToken(token);

            return new()
            {
                DataEHoraDeExpiracao = expiresIn,
                Token = strToken
            };
        }
    }
}
