using System.Web.Http;
using RedTeam.BackendInfrastructure.Foundation;
using RedTeam.Repositories;

namespace RedTeam.BackendInfrastructure.WebApi.Controllers
{
    public class ValueController : ApiController
    {
        private readonly UnitOfWork unit;
 
        public ValueController(UnitOfWork _unit)
        {
            unit = _unit;
        }

        public Survey GetSurveyById(int id)
        {
            return unit.Surveys.GetByIdAsync(id);
        }
    }
}