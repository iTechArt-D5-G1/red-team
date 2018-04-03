using System.Threading.Tasks;
using System.Web.Http;
using RedTeam.SurveyMaster.Foundation;
using RedTeam.SurveyMaster.Repositories;
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

        public async Task<Survey> GetById(int id)
        {
            return await _service.GetByIdAsync(id);
        }
    }
}