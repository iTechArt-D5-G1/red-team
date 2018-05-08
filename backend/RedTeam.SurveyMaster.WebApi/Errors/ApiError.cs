using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.ModelBinding;

namespace RedTeam.SurveyMaster.WebApi.Errors
{
    public class ApiError
    {
        public string Code;

        public string Message;

        public ICollection<KeyValuePair<string, ModelState>> Description;


        public ApiError(string code, string message = "", ICollection<KeyValuePair<string, ModelState>> descriprion = null)
        {
            Code = code;
            Message = message;
            Description = descriprion;
        }
    }
}