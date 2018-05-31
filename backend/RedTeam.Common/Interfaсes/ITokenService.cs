using System.Security.Claims;

namespace RedTeam.Common.Interfaсes
{
    public interface ITokenService
    {
        ClaimsPrincipal ParseSecurityToken(string token);

        string CreateSecurityToken(string userName, string userRoleName);
    }
}