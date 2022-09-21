 using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PhotoProject.Application.Abstractions.Services.TokenServices;
using PhotoProject.Application.DTOs.JwtDTOs;
using PhotoProject.Application.DTOs.TokenDTOs;
using PhotoProject.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PhotoProject.Infrastructure.Services.TokenServices
{
    public class TokenHandler : ITokenHandler
    {
        private readonly JwtDto _jwtDto;
        public TokenHandler(IOptions<JwtDto> jwtDto)
        {
            _jwtDto = jwtDto.Value;
        }

        public async Task<TokenDto> CreateAccessToken(AppUser model , int second , IList<string> roles)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,model.Id),
                new Claim(ClaimTypes.Email,model.Email),
                new Claim(ClaimTypes.Name,model.UserName)
                //todo you must add RoleClaims - i wrote this
            };

            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtDto.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                
                    audience:_jwtDto.AudienceValue,
                    issuer: _jwtDto.IssuerValue,
                    signingCredentials: signingCredentials,
                    claims:claims,
                    expires: DateTime.UtcNow.AddSeconds(second)
                );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            TokenDto tokenDto = new TokenDto
            {
                AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken)
            };

            return tokenDto;
        }
    }
}
