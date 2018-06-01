using System.Security.Claims;

namespace RedTeam.Common.Interfaсes
{
    public interface ITokenService
    {
        ClaimsPrincipal ParseSecurityToken(ClaimsPrincipal userClaims);

        ClaimsPrincipal CreateSecurityToken(ClaimsPrincipal userClaims);

    }
}