using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.IdentityModel.Tokens;

namespace RedTeam.SurveyMaster.WebApi
{
    internal sealed class TokenValidationHandler : DelegatingHandler
    {
        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
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


        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;
            string token;
            // determine whether a jwt exists or not
            if (!TryRetrieveToken(request, out token))
            {
                statusCode = HttpStatusCode.Unauthorized;
                // allow requests with no token - whether a action method needs an authentication can be set with the claimsauthorization attribute
                return base.SendAsync(request, cancellationToken);
            }

            try
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
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };
                // extract and assign the user of the jwt
                Thread.CurrentPrincipal = handler.ValidateToken(token, validationParameters, out securityToken);
                HttpContext.Current.User = handler.ValidateToken(token, validationParameters, out securityToken);

                return base.SendAsync(request, cancellationToken);
            }
            catch (SecurityTokenValidationException exception)
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            catch (Exception exception)
            {
                statusCode = HttpStatusCode.InternalServerError;
            }
            return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode) { });
        }


        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authHeaders;
            if (!request.Headers.TryGetValues("Authorization", out authHeaders) || authHeaders.Count() > 1)
            {
                return false;
            }
            var bearerToken = authHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }
    }
}