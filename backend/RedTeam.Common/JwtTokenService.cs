using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using RedTeam.Common.Interfaсes;
using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.Common
{
    public class JwtTokenService : ITokenService
    {
        private readonly int _exparationTime;

        private readonly string _issuerUrl;

        private readonly string _audienceUrl;

        private readonly SymmetricSecurityKey _symmerticSecurityKey;

        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler 
            = new JwtSecurityTokenHandler();


        public JwtTokenService(string securityKey, int exparationTime, string issuerUrl, string audienceUrl)
        {
            _exparationTime = exparationTime;
            _issuerUrl = issuerUrl;
            _audienceUrl = audienceUrl;
            _symmerticSecurityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(securityKey));
        }


        public ClaimsPrincipal ValidateToken(string token)
        {
            SecurityToken securityToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                ValidAudience = _audienceUrl,
                ValidIssuer = _issuerUrl,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                LifetimeValidator = ValidateLifetime,
                IssuerSigningKey = _symmerticSecurityKey
            };

            return _jwtSecurityTokenHandler.ValidateToken(token, validationParameters, out securityToken);
        }

        public SecurityToken CreateSecurityToken(string userName, string userRoleName)
        {
            DateTime issuedAt = DateTime.UtcNow;
            DateTime expires = DateTime.UtcNow.AddDays(_exparationTime);

            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, userRoleName),
                });

            var now = DateTime.UtcNow;
            var signingCredentials = new SigningCredentials(_symmerticSecurityKey,
                SecurityAlgorithms.HmacSha256Signature);

            return _jwtSecurityTokenHandler.CreateJwtSecurityToken(
                issuer: _issuerUrl,
                audience: _audienceUrl,
                subject: claimsIdentity, notBefore: issuedAt, expires: expires,
                signingCredentials: signingCredentials);
        }

        public string SerializeToken(SecurityToken token)
        {
            var serializedToken = _jwtSecurityTokenHandler.WriteToken(token);
            return serializedToken;
        }


        private static bool ValidateLifetime(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
