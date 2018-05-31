using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RedTeam.Common.Interfaсes;

namespace RedTeam.Common
{
    public class JwtTokenService : ITokenService
    {
        private readonly string _audienceUrl;

        private readonly int _exparationTime;

        private readonly string _issuerUrl;

        private readonly JwtSecurityTokenHandler _jwtTokenHandler
            = new JwtSecurityTokenHandler();

        private readonly SymmetricSecurityKey _symmerticSecurityKey;


        public JwtTokenService(string securityKey, int exparationTime, string issuerUrl, string audienceUrl)
        {
            _exparationTime = exparationTime;
            _issuerUrl = issuerUrl;
            _audienceUrl = audienceUrl;
            _symmerticSecurityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(securityKey));
        }


        public ClaimsPrincipal ParseSecurityToken(string token)
        {
            try
            {
                var validationParameters = CreateValidationParameters();
                var tokenToReturn =
                    _jwtTokenHandler.ValidateToken(token, validationParameters, out var securityToken);
                return tokenToReturn;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string CreateSecurityToken(string userName, string userRoleName)
        {
            var jwtToken = CreateConfiguredToken(userName, userRoleName);
            return SerializeToken(jwtToken);
        }


        private TokenValidationParameters CreateValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidAudience = _audienceUrl,
                ValidIssuer = _issuerUrl,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                LifetimeValidator = ValidateLifetime,
                IssuerSigningKey = _symmerticSecurityKey
            };
        }

        private SecurityToken CreateConfiguredToken(string userName, string userRoleName)
        {
            var claimsIdentity =
                new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, userRoleName)
                });

            var signingCredentials = new SigningCredentials(_symmerticSecurityKey,
                SecurityAlgorithms.HmacSha256Signature);

            var issuedAt = DateTime.UtcNow;
            var expires = DateTime.UtcNow.AddDays(_exparationTime);

            return _jwtTokenHandler.CreateJwtSecurityToken(
                _issuerUrl,
                _audienceUrl,
                claimsIdentity,
                issuedAt,
                expires,
                signingCredentials: signingCredentials);
        }

        private string SerializeToken(SecurityToken token)
        {
            var serializedToken = _jwtTokenHandler.WriteToken(token);
            return serializedToken;
        }


        private static bool ValidateLifetime(DateTime? notBefore, DateTime? expires, SecurityToken securityToken,
            TokenValidationParameters validationParameters)
        {
            return expires != null && DateTime.UtcNow < expires;
        }
    }
}