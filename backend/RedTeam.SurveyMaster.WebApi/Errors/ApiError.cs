using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RedTeam.SurveyMaster.WebApi.Errors
{
    [DataContract]
    public class ApiError
    {
        [DataMember(Name = "Code")]
        private string _code;

        [DataMember(Name = "Error Message")]
        private string _message;

        [DataMember(Name = "Description")]
        private ICollection<string> _description;


        public ApiError(string code, string message = "", ICollection<string> descriprion = null)
        {
            _code = code;
            _message = message;
            _description = descriprion;
        }
    }
}