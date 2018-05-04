using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using RedTeam.Common.Token.Interfases;

namespace RedTeam.SurveyMaster.WebApi.Authentication_Filters
{
    public class AuthenticationTokenFilter : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple { get; }


        private readonly ITokenFactory _tokenFactory;


        public AuthenticationTokenFilter(ITokenFactory tokenFactory)
        {
            _tokenFactory = tokenFactory;
        }


        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            // 1. Look for credentials in the request.
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            // 2. If there are no credentials, do nothing.
            if (authorization == null)
            {
                return;
            }

            // 3. If there are credentials but the filter does not recognize the 
            //    authentication scheme, do nothing.
            if (authorization.Scheme != "Bearer")
            {
                return;
            }

            // 4. If there are credentials that the filter understands, try to validate them.
            // 5. If the credentials are bad, set the error result.
            if (String.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing credentials", request);
                return;
            }

            var token = authorization.Parameter;
            
            if (token == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid credentials", request);
            }

            
            // extract and assign the user of the jwt
            var tokenPrincipal = _tokenFactory.CreateTokenValidator().ValidateToken(token);

            
            if (tokenPrincipal == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid username or password", request);
            }

            //// 6. If the credentials are valid, set principal.
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