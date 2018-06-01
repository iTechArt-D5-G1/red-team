using System.Linq;
using System.Security.Claims;

namespace RedTeam.Common.ExtentionMethods
{
    public static class ClaimsPrincipalExtention
    {
        public static Claim FetchAuthenticationClaim(this ClaimsPrincipal claimsPrincipal)
        {
            return FetchClaimByClaimType(claimsPrincipal, ClaimTypes.Authentication);
        }

        public static Claim FetchNameClaim(this ClaimsPrincipal claimsPrincipal)
        {
            return FetchClaimByClaimType(claimsPrincipal, ClaimTypes.Name);
        }

        public static Claim FetchRoleClaim(this ClaimsPrincipal claimsPrincipal)
        {
            return FetchClaimByClaimType(claimsPrincipal, ClaimTypes.Role);
        }


        private static Claim FetchClaimByClaimType(ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var claim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimType);
            return claim;
        }
    }
}
