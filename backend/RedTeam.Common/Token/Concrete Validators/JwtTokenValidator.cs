using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using RedTeam.Common.Token.Interfases;

namespace RedTeam.Common.Token.Concrete_Validators
{
    public class JwtTokenValidator : ITokenValidator
    {
        public ClaimsPrincipal ValidateToken(string token)
        {
            var sec = new AppSettingsReader().GetValue("SecurityKey", typeof(string)) as string;
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));

            SecurityToken securityToken;
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                ValidAudience = "http://localhost:12345",
                ValidIssuer = "http://localhost:12345",
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                LifetimeValidator = this.ValidateLifetime,
                IssuerSigningKey = securityKey
            };

            return handler.ValidateToken(token, validationParameters, out securityToken);
        }

        private bool ValidateLifetime(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
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
