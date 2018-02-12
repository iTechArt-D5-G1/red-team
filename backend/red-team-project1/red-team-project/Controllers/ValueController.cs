using System.Web.Http;
using WebApp.Domain.Core;
using WebApp.Domain.Interfaces;

namespace red_team_project.Controllers
{
    public class ValueController: ApiController
    {
        private ISurveyRepository repo;
        public ValueController(ISurveyRepository _repo)
        {
            repo = _repo;
        }
        public Survey GetSurveyById(int Id)
        {
            return repo.GetSurveyById(Id);
        }
    }
}