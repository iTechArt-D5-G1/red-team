using System.Collections.Generic;
using System.Web.Http.ModelBinding;

namespace RedTeam.Common.ExtentionMethods
{
    public static class ModelStateDictionaryExtention
    {
        public static List<string> FetchErrorsFromModelState(this ModelStateDictionary modelStateDictionary)
        {
            List<string> errorDescriptionList =
                new List<string>();

            foreach (var modelState in modelStateDictionary)
            {
                foreach (var error in modelState.Value.Errors)
                {
                    errorDescriptionList.Add(error.ErrorMessage);
                }
            }

            return errorDescriptionList;
        }
    }
}
