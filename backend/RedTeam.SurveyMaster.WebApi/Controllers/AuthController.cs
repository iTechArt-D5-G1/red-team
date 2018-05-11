using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using RedTeam.Common.Token.Interfaces;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.Repositories.DataTransferObjectModels;
using RedTeam.SurveyMaster.Repositories.Models;
using RedTeam.SurveyMaster.WebApi.Errors;

namespace RedTeam.SurveyMaster.WebApi.Controllers
{
    [AllowAnonymous]
    public class AuthController : ApiController
    {
        private readonly IUserService _userService;

        private readonly IRoleService _roleService;

        private readonly ITokenFactory _tokenFactory;


        public AuthController(IUserService userService, IRoleService roleService, ITokenFactory tokenFactory)
        {
            _userService = userService;
            _roleService = roleService;
            _tokenFactory = tokenFactory;
        }


        [HttpPost]
        public async Task<IHttpActionResult> Authenticate([FromBody] UserDto userInfo)
        {
            if (!ModelState.IsValid)
            {
                ApiError error = new ApiError("invalid_credentials", "Invalid user credentials", ModelState);
                return new ApiErrorResult(HttpStatusCode.BadRequest, error);
            }

            if (await _userService.IsUserExistsAsync(userInfo.Password, userInfo.Username))
            {
                var user = await _userService.GetUserAsync(userInfo.Password, userInfo.Username);
                var userRole = await _roleService.GetByIdAsync(user.RoleId);
                string token = CreateToken(userInfo.Username, userRole);
                return Ok<string>(token);
            }
            else
            {
                ApiError error = new ApiError("user_not_found", "User with setted params not found");
                return new ApiErrorResult(HttpStatusCode.NotFound, error);
            }
        }


        private string CreateToken(string userName, Role userRole)
        {
            var tokenCreator = _tokenFactory.CreateTokenCreator();
            var token = tokenCreator.CreateSecurityToken(userName, userRole);
            return tokenCreator.SerializeToken(token);;
        }
    }
}
