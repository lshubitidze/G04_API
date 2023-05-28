using Fasade.Interfaces.JwtToken;
using Fasade.Interfaces.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly ITokenParameters _tokenParameters;

        public AuthorizationService(ITokenParameters tokenParameters)
        {
            _tokenParameters = tokenParameters;
        }

        public JwtSecurityToken CreateJwtToken(IdentityUser user) =>
            new (
                _tokenParameters.ValidIssuer,
                _tokenParameters.ValidAudience,
                CreateClaims(user),
                expires: DateTime.UtcNow.AddMinutes(_tokenParameters.ExpirationMinutes),
                signingCredentials: CreateSigningCredentials()
            );

        private SigningCredentials CreateSigningCredentials() => 
            new(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_tokenParameters.Key)
                ),
                SecurityAlgorithms.HmacSha256
            );

        private IEnumerable<Claim> CreateClaims(IdentityUser user) =>
            new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _tokenParameters.ValidIssuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };
    }
}
