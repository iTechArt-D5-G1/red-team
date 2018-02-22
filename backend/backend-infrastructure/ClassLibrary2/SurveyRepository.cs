using red_team.backend_infrastructure.Foundation;
using red_team.backend_infrastructure.Repositories;
using red_team.backend_infrastructure.Repositories.Interfaces;
using red_team.Repositories.Interfaces;

namespace red_team.Repositories
{
    public class SurveyRepository: IRepository<Survey>
    {
        private readonly SurveyContext context;

        public SurveyRepository(SurveyContext _context)
        {
            context = _context;
        }
        public Survey GetByIdAsync(int id)
        {
            return context.Surveys.Find(id);
        }
    }
}

