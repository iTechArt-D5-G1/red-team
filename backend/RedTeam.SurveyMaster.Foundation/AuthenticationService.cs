using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using RedTeam.Common.Interfaсes;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.SurveyMaster.Foundation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;

        private readonly ITokenService _tokenService;


        public AuthenticationService(ITokenService tokenService, UserManager<User> userManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }


        public async Task<ClaimsPrincipal> AuthenticateUserAsync(string userName, string password)
        {
            if (await IsUserExistsAsync(userName, password))
            {
                var userRoleName = await GetUserRoleNameAsync(userName);

                var securityToken = CreateSecurityToken(userName, userRoleName);

                var userAuthenticationIdentityClaims = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Authentication, securityToken) 
                });

                var userAuthenticationClaimsPrincipal = new ClaimsPrincipal(userAuthenticationIdentityClaims);
                return userAuthenticationClaimsPrincipal;
            }

            return null;
        }


        private async Task<bool> IsUserExistsAsync(string userName, string password)
        {
            return await _userManager.FindAsync(userName, password) != null;
        }

        private async Task<string> GetUserRoleNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var userRoleName = _userManager.GetRoles(user.Id).FirstOrDefault();
            return userRoleName;
        }

        private string CreateSecurityToken(string userName, string userRoleName)
        {
            var userClaimsIdentity =
                new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, userRoleName)
                });
            var userClaimsPrincipal = new ClaimsPrincipal(userClaimsIdentity);

            return _tokenService.CreateSecurityToken(userClaimsPrincipal);
        }
    }
}
