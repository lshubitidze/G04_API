using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Fasade.Interfaces.Service
{
    public interface IAuthorizationService
    {
        JwtSecurityToken CreateJwtToken(IdentityUser user);
    }
}
