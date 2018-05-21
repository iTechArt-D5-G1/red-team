using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RedTeam.Common.Interfaсes;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.Repositories;
using RedTeam.SurveyMaster.Repositories.Models;
using RedTeam.SurveyMaster.WebApi.DataTransferObjectModels;
using RedTeam.SurveyMaster.WebApi.Errors;

namespace RedTeam.SurveyMaster.WebApi.Controllers
{
    [AllowAnonymous]
    public class AuthController : ApiController
    {

        private readonly ITokenService _tokenService;


        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }


        [HttpPost]
        public async Task<IHttpActionResult> Authenticate([FromBody] UserDto userInfo)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<UserManager>();

            if (!ModelState.IsValid)
            {
                ApiError error = new ApiError("invalid_credentials", "Invalid user credentials",
                    FetchErrorsFromModelState(ModelState));
                return new ApiErrorResult(HttpStatusCode.BadRequest, error);
            }

            if (await userManager.FindByEmailAsync(userInfo.Username) != null)
            {
                var userFromUserManager = await userManager.FindByEmailAsync(userInfo.Username);
                var userRole = userManager.GetRoles(userFromUserManager.Id).FirstOrDefault();
                string token = CreateToken(userInfo.Username, userRole);
                return Ok(token);
            }
            else
            {
                ApiError error = new ApiError("user_not_found", "User with setted params not found");
                return new ApiErrorResult(HttpStatusCode.NotFound, error);
            }
        }


        private string CreateToken(string userName, string userRoleName)
        {
            var token = _tokenService.CreateSecurityToken(userName, userRoleName);
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
