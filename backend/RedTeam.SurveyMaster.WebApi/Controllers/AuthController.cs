using System.Threading.Tasks;
using System.Web.Http;
using RedTeam.Common.ExtentionMethods;
using RedTeam.Common.Interfaсes;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.WebApi.Dtos;
using RedTeam.SurveyMaster.WebApi.Factories.Interfaces;

namespace RedTeam.SurveyMaster.WebApi.Controllers
{
    [AllowAnonymous]
    public class AuthController : ApiController
    {

        private readonly IAuthenticationService _authenticationService;

        private readonly ITokenService _tokenService;

        private readonly IGlobalApplicationErrorsFactory _errorsFactory;


        public AuthController(IAuthenticationService authenticationService, ITokenService tokenService, IGlobalApplicationErrorsFactory errorsFactory)
        {
            _authenticationService = authenticationService;
            _tokenService = tokenService;
            _errorsFactory = errorsFactory;
        }


        [HttpPost]
        public async Task<IHttpActionResult> Authenticate([FromBody] UserDto userInfo)
        {

            if (!ModelState.IsValid)
            {
                return _errorsFactory.InvalidCredentialsResult("Invalid credentials",
                    ModelState.FetchErrorsFromModelState());
            }

            if (await _authenticationService.IsUserExistsAsync(userInfo.Username, userInfo.Password))
            {
                var userRoleName = await _authenticationService.GetUserRoleNameAsync(userInfo.Username);
                var token = _tokenService.CreateSecurityToken(userInfo.Username, userRoleName);
                return Ok(token);
            }

            return _errorsFactory.UserNotFoundResult();
        }
    }
}
