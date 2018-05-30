using System.Collections.Generic;
using RedTeam.SurveyMaster.WebApi.Errors;

namespace RedTeam.SurveyMaster.WebApi.Factories.Interfaces
{
    public interface IGlobalApplicationErrorsFactory
    {
        ApiErrorResult UserNotFoundResult(string message = "User not found", List<string> descriptionList = null);

        ApiErrorResult InvalidCredentialsResult(string message = "Invalid credentials",
            List<string> descriptionList = null);

        ApiErrorResult MissingCredentialsResult(string message = "Missing credentials",
            List<string> descriptionList = null);
    }
}
