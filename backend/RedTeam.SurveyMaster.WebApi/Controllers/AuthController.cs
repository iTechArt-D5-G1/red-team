using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using RedTeam.Common.ExtentionMethods;
using RedTeam.Common.Interfaсes;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.WebApi.Dtos;
using RedTeam.SurveyMaster.WebApi.Errors;

namespace RedTeam.SurveyMaster.WebApi.Controllers
{
    [AllowAnonymous]
    public class AuthController : ApiController
    {

        private readonly IAuthenticationService _authenticationService;

        private readonly ITokenService _tokenService;


        public AuthController(IAuthenticationService authenticationService, ITokenService tokenService)
        {
            _authenticationService = authenticationService;
            _tokenService = tokenService;
        }


        [HttpPost]
        public async Task<IHttpActionResult> Authenticate([FromBody] UserDto userInfo)
        {

            if (!ModelState.IsValid)
            {
                return new ApiErrorResult(HttpStatusCode.BadRequest, new ApiError(AuthenticationErrorCodes.InvalidCredentials, "Invalid credentials",
                    ModelState.FetchErrorsFromModelState()));
            }

            if (await _authenticationService.IsUserExistsAsync(userInfo.Username, userInfo.Password))
            {
                var userRoleName = await _authenticationService.GetUserRoleNameAsync(userInfo.Username);
                var token = _tokenService.CreateSecurityToken(userInfo.Username, userRoleName);
                return Ok(token);
            }

            return new ApiErrorResult(HttpStatusCode.NotFound,
                new ApiError(AuthenticationErrorCodes.UserNotFound, "User not found"));
        }
    }
}
