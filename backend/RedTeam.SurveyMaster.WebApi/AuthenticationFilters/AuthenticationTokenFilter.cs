using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

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
                ApiError error = new ApiError("missing_credentials", "Missing credentials");
                context.ErrorResult = new ApiErrorResult(HttpStatusCode.NotFound, error);
                return;
            }

            var token = authorization.Parameter;
            var tokenPrincipal = _tokenService.ValidateToken(token);

            if (tokenPrincipal == null)
            {
                ApiError error = new ApiError("invalid_credentials", "Invalid username or password");
                context.ErrorResult = new ApiErrorResult(HttpStatusCode.BadRequest, error);
            }
            else
            {
                context.Principal = tokenPrincipal;
            }
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
        }
    }
}