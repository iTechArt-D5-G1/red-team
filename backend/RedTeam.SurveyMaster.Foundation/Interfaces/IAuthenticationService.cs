using System.Threading.Tasks;

namespace RedTeam.SurveyMaster.Foundation.Interfaces
{
    public interface IAuthenticationService
    {
        string CreateToken(string userName, string userRoleName);

        Task<bool> IsUserExistsAsync(string userName, string password);

        Task<string> GetUserRoleNameAsync(string userName);

    }
}
