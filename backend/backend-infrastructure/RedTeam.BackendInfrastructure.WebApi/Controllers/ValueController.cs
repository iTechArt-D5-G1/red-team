using RedTeam.BackendInfrastructure.Foundation;
using RedTeam.Repositories;
using System.Web.Http;

namespace RedTeam.BackendInfrastructure.WebApi.WebApi.Controllers
{
    public class ValueController : ApiController
    {
        private readonly UnitOfWork unit;
 
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