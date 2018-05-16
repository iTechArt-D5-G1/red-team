using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using RedTeam.Common.Interfaсes;

namespace RedTeam.SurveyMaster.WebApi.AuthenticationFilters
{
    public class AuthenticationTokenFilter : Attribute, IAuthenticationFilter
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
                context.ErrorResult = new AuthenticationFailureResult("Missing credentials", request);
                return;
            }

            var token = authorization.Parameter;
            var tokenPrincipal = _tokenService.ValidateToken(token);

            
            if (tokenPrincipal == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid username or password", request);
            }

            else
            {
                context.Principal = tokenPrincipal;
            }
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var challenge = new AuthenticationHeaderValue("Basic");
            context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);
            return Task.FromResult(0);
        }
    }
}