using System.Web.Http;
using RedTeam.Repositories.Interfaces;
using RedTeam.SurveyMaster.Foundation;

namespace RedTeam.SurveyMaster.WebApi.Controllers
{
    public class ValueController : ApiController
    {
        readonly IServise _servise;
 
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