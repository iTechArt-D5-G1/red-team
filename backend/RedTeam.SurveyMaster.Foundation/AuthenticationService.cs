using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using RedTeam.Common.Interfaсes;
using RedTeam.SurveyMaster.Foundation.Interfaces;

namespace RedTeam.SurveyMaster.Foundation
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IUserManagerFactory _userManagerFactory;

        private readonly ITokenService _tokenService;


        public AuthenticationService(IUserManagerFactory userManagerFactory, ITokenService tokenService)
        {
            _userManagerFactory = userManagerFactory;
            _tokenService = tokenService;
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

        public async Task<ClaimsPrincipal> AuthenticateUserAsync(string userName, string password)
        {
            if (await IsUserExistsAsync(userName, password))
            {
                var userRoleName = await GetUserRoleNameAsync(userName);

                var userClaimsIdentity =
                    new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, userName),
                        new Claim(ClaimTypes.Role, userRoleName)
                    });
                var userClaimsPrincipal = new ClaimsPrincipal(userClaimsIdentity);

                return _tokenService.CreateSecurityToken(userClaimsPrincipal);
            }

            return null;
        }
    }
}
