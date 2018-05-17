using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using RedTeam.Common.Interfaсes;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.Repositories.Models;
using RedTeam.SurveyMaster.WebApi.DataTransferObjectModels;
using RedTeam.SurveyMaster.WebApi.Errors;

namespace RedTeam.SurveyMaster.WebApi.Controllers
{
    [AllowAnonymous]
    public class AuthController : ApiController
    {
        private readonly IUserService _userService;

        private readonly IRoleService _roleService;

        private readonly ITokenService _tokenService;


        public AuthController(IUserService userService, IRoleService roleService, ITokenService tokenService)
        {
            _userService = userService;
            _roleService = roleService;
            _tokenService = tokenService;
        }


        [HttpPost]
        public async Task<IHttpActionResult> Authenticate([FromBody] UserDto userInfo)
        {
            if (!ModelState.IsValid)
            {
                ApiError error = new ApiError("invalid_credentials", "Invalid user credentials",
                    FetchErrorsFromModelState(ModelState));
                return new ApiErrorResult(HttpStatusCode.BadRequest, error);
            }

            if (await _userService.IsUserExistsAsync(userInfo.Password, userInfo.Username))
            {
                var user = await _userService.GetUserAsync(userInfo.Password, userInfo.Username);
                var userRole = await _roleService.GetByIdAsync(user.RoleId);
                string token = CreateToken(userInfo.Username, userRole);
                return Ok(token);
            }
            else
            {
                ApiError error = new ApiError("user_not_found", "User with setted params not found");
                return new ApiErrorResult(HttpStatusCode.NotFound, error);
            }
        }


        private string CreateToken(string userName, Role userRole)
        {
            var token = _tokenService.CreateSecurityToken(userName, userRole);
            return _tokenService.SerializeToken(token);
        }

        private static List<string> FetchErrorsFromModelState(ModelStateDictionary modelStateDictionary)
        {
            List<string> errorDescriptionList =
                new List<string>();

            foreach (var modelState in modelStateDictionary)
            {
                foreach (var error in modelState.Value.Errors)
                {
                    errorDescriptionList.Add(error.ErrorMessage);
                }
            }

            return errorDescriptionList;
        }
    }
}
