using System;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Autofac.Integration.WebApi;
using RedTeam.Common.Interfaсes;
using RedTeam.SurveyMaster.WebApi.Errors;

namespace RedTeam.SurveyMaster.WebApi.AuthenticationFilters
{
    public class AuthenticationTokenFilter : Attribute, IAutofacAuthenticationFilter
    {
        public bool AllowMultiple { get; }


        private readonly ITokenService _tokenService;


        public AuthenticationTokenFilter(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }


        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null)
            {
                return;
            }

            if (authorization.Scheme != "Bearer")
            {
                return;
            }

            if (String.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new ApiErrorResult(HttpStatusCode.BadRequest,
                    new ApiError(AuthenticationErrorCodes.MissingCredentials, "Token is empty"));
                return;
            }

            var token = authorization.Parameter;
            Validate(token, context);
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
        }


        private void Validate(string token, HttpAuthenticationContext context)
        {
            ValidateToken(token, out ClaimsPrincipal tokenPrincipal);

            if (tokenPrincipal == null)
            {
                context.ErrorResult = new ApiErrorResult(HttpStatusCode.BadRequest,
                    new ApiError(AuthenticationErrorCodes.InvalidCredentials, "Token is invalid"));
            }
            else
            {
                context.Principal = tokenPrincipal;
            }
        }

        private void ValidateToken(string token, out ClaimsPrincipal tokenPrincipal)
        {
            var claimIdentity = new ClaimsIdentity(new []
            {
                new Claim(ClaimTypes.Authentication, token) 
            });
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);

            tokenPrincipal = _tokenService.ParseSecurityToken(claimPrincipal);
        }
    }
}