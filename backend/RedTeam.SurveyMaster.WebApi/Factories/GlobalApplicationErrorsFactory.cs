using System.Collections.Generic;
using System.Net;
using RedTeam.SurveyMaster.WebApi.Errors;
using RedTeam.SurveyMaster.WebApi.Factories.Interfaces;

namespace RedTeam.SurveyMaster.WebApi.Factories
{
    public class GlobalApplicationErrorsFactory : IGlobalApplicationErrorsFactory
    {
        public ApiErrorResult UserNotFoundResult(string message = "User not found", List<string> descriptionList = null)
        {
            var error = new ApiError("user_not_found", message, descriptionList);
            return new ApiErrorResult(HttpStatusCode.NotFound, error);
        }

        public ApiErrorResult InvalidCredentialsResult(string message = "Invalid credentials", List<string> descriptionList = null)
        {
            var error = new ApiError("invalid_credentials", message, descriptionList);
            return new ApiErrorResult(HttpStatusCode.BadRequest, error);
        }

        public ApiErrorResult MissingCredentialsResult(string message = "Missing credentials", List<string> descriptionList = null)
        {
            var error = new ApiError("missing_credentials", message, descriptionList);
            return new ApiErrorResult(HttpStatusCode.NotFound, error);
        }
    }
}