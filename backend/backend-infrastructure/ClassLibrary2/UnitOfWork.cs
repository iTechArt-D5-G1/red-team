using red_team.backend_infrastructure.Repositories;
using System;

namespace red_team.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private SurveyContext db = new SurveyContext();
        private SurveyRepository repository;
 
        public SurveyRepository Surveys
        {
            get
            {
                if (repository == null)
                    repository = new SurveyRepository(db);
                return repository;
            }
        }
        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
