using System.Security.Claims;

namespace RedTeam.Common.Interfaсes
{
    public interface ITokenService
    {
        ClaimsPrincipal ParseSecurityToken(string securityToken);

        string CreateSecurityToken(ClaimsPrincipal userClaims);

    }
}