using System.Security.Claims;

namespace RedTeam.Common.Token.Interfaces
{
    public interface ITokenValidator
    {
        ClaimsPrincipal ValidateToken(string token);
    }
}
