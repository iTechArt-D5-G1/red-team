using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.Common.Interfaсes
{
    public interface ITokenService
    {
        ClaimsPrincipal ValidateToken(string token);

        SecurityToken CreateSecurityToken(string userName, Role userRole);

        string SerializeToken(SecurityToken token);
    }
}
