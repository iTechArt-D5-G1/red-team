using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using RedTeam.Common.Token.Interfaces;
using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.Common.Token.Concrete_Token_Creators
{
    public class JwtTokenCreator : ITokenCreator
    {
        public SecurityToken CreateSecurityToken(string userName, Role userRole)
        {
            var appSettingsReader = new AppSettingsReader();

            DateTime issuedAt = DateTime.UtcNow;
            var expirationTokenTime = (int)appSettingsReader.GetValue("ExpirationTokenTime", typeof(int));
            DateTime expires = DateTime.UtcNow.AddDays(expirationTokenTime);
            var tokenHandler = new JwtSecurityTokenHandler();

            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, userRole.Name),
                });

            var sec = appSettingsReader.GetValue("SecurityKey", typeof(string)) as string;

            var now = DateTime.UtcNow;
            var securityKey =
                new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey,
                Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);

            return (JwtSecurityToken)
                tokenHandler.CreateJwtSecurityToken(
                    issuer: "http://localhost:12345",
                    audience: "http://localhost:12345",
                    subject: claimsIdentity, notBefore: issuedAt, expires: expires,
                    signingCredentials: signingCredentials);
        }

        public string SerializeToken(SecurityToken token)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var serializedToken = tokenHandler.WriteToken(token);
            return serializedToken;
        }
    }
}
