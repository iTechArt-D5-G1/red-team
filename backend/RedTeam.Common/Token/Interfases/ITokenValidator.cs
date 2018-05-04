using System.Security.Claims;

namespace RedTeam.Common.Token.Interfases
{
    public interface ITokenValidator
    {
        ClaimsPrincipal ValidateToken(string token);
    }
}
