using red_team.backend_infrastructure.Foundation;
using red_team.backend_infrastructure.Repositories;

namespace ClassLibrary6
{
    class SurveyRepository: ISurveyRepository
    {
        private readonly ISurveyContext context;
        public SurveyRepository(ISurveyContext _context)
        {
            context = _context;
        }
        public Survey GetSurveyById(int id)
        {
            return context.Surveys.Find(id);
        }
    }
}
