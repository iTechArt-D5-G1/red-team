using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using RedTeam.Common.ExtentionMethods;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.WebApi.Dtos;
using RedTeam.SurveyMaster.WebApi.Errors;

namespace RedTeam.SurveyMaster.WebApi.Controllers
{
    [AllowAnonymous]
    public class AuthController : ApiController
    {

        private readonly IAuthenticationService _authenticationService;


        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        [HttpPost]
        public async Task<IHttpActionResult> Authenticate([FromBody] UserDto userInfo)
        {
            if (!ModelState.IsValid)
            {
                return new ApiErrorResult(HttpStatusCode.BadRequest, new ApiError(AuthenticationErrorCodes.InvalidCredentials, "Invalid credentials",
                    ModelState.FetchErrorsFromModelState()));
            }

            var userClaimsPrincipal = await _authenticationService.AuthenticateUserAsync(userInfo.Username, userInfo.Password);
            if (userClaimsPrincipal == null)
            {
                return new ApiErrorResult(HttpStatusCode.NotFound,
                    new ApiError(AuthenticationErrorCodes.UserNotFound, "User not found"));
            }

            var userAuthenticationClaim = userClaimsPrincipal.FetchAuthenticationClaim();
            return Ok(userAuthenticationClaim.Value);
        }
    }
}
