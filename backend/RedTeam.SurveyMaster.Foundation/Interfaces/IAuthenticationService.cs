using System.Security.Claims;
using System.Threading.Tasks;

namespace RedTeam.SurveyMaster.Foundation.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ClaimsPrincipal> AuthenticateUserAsync(string userName, string password);
    }
}
