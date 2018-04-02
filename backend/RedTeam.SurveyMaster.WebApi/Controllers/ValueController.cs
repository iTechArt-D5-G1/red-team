using System.Web.Http;
using RedTeam.SurveyMaster.Foundation;
using RedTeam.SurveyMaster.Repositories.Interfaces;

namespace RedTeam.SurveyMaster.WebApi.Controllers
{
    public class ValueController : ApiController
    {
        private readonly ISurveyService _service;

 
        public ValueController(ISurveyService service)
        {
            _service = service;
        }

        public Survey GetById(int id)
        {
            return _service.GetById(id).Result;
        }
    }
}