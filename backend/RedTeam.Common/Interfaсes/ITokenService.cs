using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace RedTeam.Common.Interfaсes
{
    public interface ITokenService
    {
        ClaimsPrincipal ValidateToken(string token);

        SecurityToken CreateSecurityToken(string userName, string userRoleName);

        string SerializeToken(SecurityToken token);
    }
}
