using System.Threading.Tasks;

namespace RedTeam.SurveyMaster.Foundation.Interfaces
{
    public interface IAuthenticationService
    {

        Task<bool> IsUserExistsAsync(string userName, string password);

        Task<string> GetUserRoleNameAsync(string userName);

    }
}
