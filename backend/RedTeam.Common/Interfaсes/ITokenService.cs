using System.Security.Claims;

namespace RedTeam.Common.Interfaсes
{
    public interface ITokenService
    {
        ClaimsPrincipal ValidateToken(string token);

        string CreateSecurityToken(string userName, string userRoleName);
    }
}