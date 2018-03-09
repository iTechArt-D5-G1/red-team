using System.Web.Http;
using RedTeam.BackendInfrastructure.Foundation;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.BackendInfrastructure.WebApi.Controllers
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