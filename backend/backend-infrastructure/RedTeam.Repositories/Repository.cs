using System.Linq;
using RedTeam.BackendInfrastructure.Foundation;
using RedTeam.BackendInfrastructure.Repositories;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.Repositories
{
    public class Repository<TEntity> : IRepository<Survey>
    {
        private readonly SurveyContext context;
        public Repository(SurveyContext _context)
        {
            context = _context;
        }

        public void Delete(Survey entity)
        {
            throw new System.NotImplementedException();
        }

        public Survey GetByIdAsync(int id)
        {
            return context.Surveys.Find(id);
        }

        public IQueryable<Survey> GetQuery()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Survey entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
