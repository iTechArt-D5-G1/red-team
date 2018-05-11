using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;

namespace RedTeam.SurveyMaster.WebApi.Errors
{
    public class ApiErrorResult : IHttpActionResult
    {
        private readonly ApiError _error;

        private readonly HttpStatusCode _statusCode;


        public ApiErrorResult(HttpStatusCode statusCode, ApiError error )
        {
            _statusCode = statusCode;
            _error = error;
        }


        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(_statusCode);
            var serializedErrorObject = JsonConvert.SerializeObject(_error);
            response.Content = new StringContent(serializedErrorObject, Encoding.UTF8, "application/json");
            return Task.FromResult(response);
        }
    }
}