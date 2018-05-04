using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RedTeam.Common.Token.Interfases;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.Repositories.DataTransferObjectModels;
using RedTeam.SurveyMaster.Repositories.Models;

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
        public IHttpActionResult Authenticate([FromBody] UserDto userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = FindUserInDb(userInfo);

            if (user != null)
            {
                var userRole = _roleService.GetAllRoles().FirstOrDefault(r => r.Id == user.RoleId);
                string token = CreateToken(userInfo.Username, userRole);
                return Ok<string>(token);
            }
            else
            {
                HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.Unauthorized,
                    "The email or password you entered is invalid");
                return ResponseMessage(responseMessage);
            }
        }

        private User FindUserInDb(UserDto userInfo)
        {
            if (userInfo != null)
            {
                return _userService.GetAllUsers()
                    .FirstOrDefault(u => u.Password == userInfo.Password && u.Username == userInfo.Username);
            }

            return null;
        }

        private string CreateToken(string userName, Role userRole)
        {
            var tokenCreator = _tokenFactory.CreateTokenCreator();
            var token = tokenCreator.CreateSecurityToken(userName, userRole);
            return tokenCreator.SerializeToken(token);;
        }
    }
}
