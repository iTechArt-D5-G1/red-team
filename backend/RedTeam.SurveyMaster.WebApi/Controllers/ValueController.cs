using System.Threading.Tasks;
using System.Web.Http;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.SurveyMaster.WebApi.Controllers
{
    [AllowAnonymous]
    public class ValueController : ApiController
    {
        private readonly ISurveyService _service;

 
        public ValueController(ISurveyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<Survey> GetById(int id)
        {
            return await _service.GetByIdAsync(id);
        }
    }
}