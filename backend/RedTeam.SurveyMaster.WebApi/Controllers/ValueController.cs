using System.Web.Http;
using RedTeam.SurveyMaster.Foundation;
using RedTeam.SurveyMaster.Repositories.Interfaces;

namespace RedTeam.SurveyMaster.WebApi.Controllers
{
    public class ValueController : ApiController
    {
        private readonly IServise _servise;
 
        public ValueController(IServise servise)
        {
            _servise = servise;
        }

        public Survey GetById(int id)
        {
            return _servise.GetById(id);
        }
    }
}