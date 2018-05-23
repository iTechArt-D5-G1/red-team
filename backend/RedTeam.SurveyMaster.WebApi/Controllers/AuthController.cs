using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using RedTeam.Common.ExtentionMethods;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.WebApi.DataTransferObjectModels;
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
                ApiError error = new ApiError("invalid_credentials", "Invalid user credentials",
                    ModelState.FetchErrorsFromModelState());
                return new ApiErrorResult(HttpStatusCode.BadRequest, error);
            }

            if (await _authenticationService.IsUserExistsAsync(userInfo.Username, userInfo.Password))
            {
                var userRoleName = await _authenticationService.GetUserRoleNameAsync(userInfo.Username);
                string token = _authenticationService.CreateToken(userInfo.Username, userRoleName);
                return Ok(token);
            }
            else
            {
                ApiError error = new ApiError("user_not_found", "User with setted params not found");
                return new ApiErrorResult(HttpStatusCode.NotFound, error);
            }
        }
    }
}
