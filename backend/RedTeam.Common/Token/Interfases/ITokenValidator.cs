
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace RedTeam.Common.Token.Interfases
{
    public interface ITokenValidator
    {
        ClaimsPrincipal ValidateToken(string token);
    }
}
