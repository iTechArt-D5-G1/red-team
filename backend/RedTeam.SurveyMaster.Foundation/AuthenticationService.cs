using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using RedTeam.SurveyMaster.Foundation.Interfaces;

namespace RedTeam.SurveyMaster.Foundation
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IUserManagerFactory _userManagerFactory;


        public AuthenticationService(IUserManagerFactory userManagerFactory)
        {
            _userManagerFactory = userManagerFactory;
        }


        public async Task<bool> IsUserExistsAsync(string userName, string password)
        {
            var userManager = _userManagerFactory.GetUserManager();
            return await userManager.FindAsync(userName, password) != null;
        }

        public async Task<string> GetUserRoleNameAsync(string userName)
        {
            var userManager = _userManagerFactory.GetUserManager();
            var user = await userManager.FindByNameAsync(userName);
            var userRoleName = userManager.GetRoles(user.Id).FirstOrDefault();
            return userRoleName;
        }
    }
}
