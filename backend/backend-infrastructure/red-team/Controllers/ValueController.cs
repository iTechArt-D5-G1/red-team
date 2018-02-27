using red_team.backend_infrastructure.Foundation;
using red_team.Repositories;
using System.Web.Http;

namespace red_team.backend_infrastructure.WebApi.Controllers
{
    public class ValueController : ApiController
    {
        private UnitOfWork unit;
 
        public ValueController(UnitOfWork _unit)
        {
            unit = _unit;
        }
        public Survey GetSurveyById(int Id)
        {
            return unit.Surveys.GetByIdAsync(Id);
        }
    }
}