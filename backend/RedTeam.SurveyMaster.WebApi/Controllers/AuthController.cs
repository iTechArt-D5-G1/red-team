using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
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
                return CreateInvalidModelStateResult(ModelState);
            }

            if (await _authenticationService.IsUserExistsAsync(userInfo.Username, userInfo.Password))
            {
                var userRoleName = await _authenticationService.GetUserRoleNameAsync(userInfo.Username);
                string token = CreateToken(userInfo.Username, userRoleName);
                return Ok(token);
            }

            return CreateUserNotFoundResult();
        }


        private IHttpActionResult CreateUserNotFoundResult()
        {
            ApiError error = new ApiError("user_not_found", "User with setted params not found");
            return new ApiErrorResult(HttpStatusCode.NotFound, error);
        }

        private ApiErrorResult CreateInvalidModelStateResult(ModelStateDictionary modelState)
        {
            ApiError error = new ApiError("invalid_credentials", "Invalid user credentials",
                ModelState.FetchErrorsFromModelState());
            return new ApiErrorResult(HttpStatusCode.BadRequest, error);
        }

        private string CreateToken(string userName, string userRoleName)
        {
            var token = _tokenService.CreateSecurityToken(userName, userRoleName);
            return _tokenService.SerializeToken(token);
        }
    }
}
