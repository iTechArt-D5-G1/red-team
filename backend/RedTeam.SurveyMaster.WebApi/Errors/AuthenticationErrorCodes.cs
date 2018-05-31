
namespace RedTeam.SurveyMaster.WebApi.Errors
{
    public static class AuthenticationErrorCodes
    {
        public static readonly string UserNotFound = "user_no_found";

        public static readonly string InvalidCredentials = "invalid_credentials";

        public static readonly string MissingCredentials = "missing_credentials";
    }
}