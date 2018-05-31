using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Autofac.Integration.WebApi;
using RedTeam.Common.Interfaсes;
using RedTeam.SurveyMaster.WebApi.Factories.Interfaces;

namespace RedTeam.SurveyMaster.WebApi.AuthenticationFilters
{
    public class AuthenticationTokenFilter : Attribute, IAutofacAuthenticationFilter
    {
        public bool AllowMultiple { get; }


        private readonly ITokenService _tokenService;

        private readonly IGlobalApplicationErrorsFactory _errorsFactory;


        public AuthenticationTokenFilter(ITokenService tokenService, IGlobalApplicationErrorsFactory errorsFactory)
        {
            _tokenService = tokenService;
            _errorsFactory = errorsFactory;
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
                context.ErrorResult = _errorsFactory.MissingCredentialsResult("Token is empty");
                return;
            }

            var token = authorization.Parameter;
            Validate(token, context);
        }

        private void Validate(string token, HttpAuthenticationContext context)
        {
                ValidateToken(token, out ClaimsPrincipal tokenPrincipal);

                if (tokenPrincipal == null)
                {
                    context.ErrorResult = _errorsFactory.InvalidCredentialsResult("Token is invalid");
                }
                else
                {
                    context.Principal = tokenPrincipal;
                }
        }

        private void ValidateToken(string token, out ClaimsPrincipal tokenPrincipal)
        {
            tokenPrincipal = _tokenService.ParseSecurityToken(token);
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
        }
    }
}