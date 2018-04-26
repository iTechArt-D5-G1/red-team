using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.Repositories.Models;


namespace RedTeam.SurveyMaster.WebApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private readonly IUserService _service;
        private enum UserRoles { Admin = 1, User };


        public AuthController(IUserService service)
        {
            _service = service;
        }

        [Route("token")]
        [HttpPost]
        public IHttpActionResult Authenticate([FromBody] User userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = null;

            if (userInfo != null)
                user = _service.GetAllUsers()
                    .FirstOrDefault(u => u.Password == userInfo.Password && u.Username == userInfo.Username);

            if (user != null)
            {
                bool isUserAdmin = (user.RoleId == (int)UserRoles.Admin);
                string token = CreateToken(userInfo.Username, isUserAdmin);
                return Ok<string>(token);
            }
            else
            {
                HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.Unauthorized,
                    "The email or password you entered is invalid");
                return ResponseMessage(responseMessage);
            }
        }

        private string CreateToken(string username, bool isUserAdmin)
        {
            DateTime issuedAt = DateTime.UtcNow;
            DateTime expires = DateTime.UtcNow.AddDays(7);
            var tokenHandler = new JwtSecurityTokenHandler();
            ClaimsIdentity claimsIdentity = null;

            if (isUserAdmin)
            {
                claimsIdentity = CreateAdminClaim(username);
            }
            else
            {
                claimsIdentity = CreateUserClaim(username);
            }

            const string sec =
                "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var now = DateTime.UtcNow;
            var securityKey =
                new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey,
                Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token =
                (JwtSecurityToken)
                tokenHandler.CreateJwtSecurityToken(issuer: "http://localhost:12345",
                    audience: "http://localhost:12345",
                    subject: claimsIdentity, notBefore: issuedAt, expires: expires,
                    signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        private ClaimsIdentity CreateUserClaim(string username)
        {
            return new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "user"),
            });
        }

        private ClaimsIdentity CreateAdminClaim(string username)
        {
            return new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "admin"),
            });
        }
    }
}
