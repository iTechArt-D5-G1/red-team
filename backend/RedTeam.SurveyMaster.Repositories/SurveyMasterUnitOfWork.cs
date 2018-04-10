using RedTeam.Repositories;
using RedTeam.SurveyMaster.Repositories.Interfaces;

namespace RedTeam.SurveyMaster.Repositories
{
    public class SurveyMasterUnitOfWork : UnitOfWork<SurveyMasterDbContext>, ISurveyMasterUnitOfWork
    {
        public SurveyMasterUnitOfWork(SurveyMasterDbContext dbContext) : base(dbContext)
        {
            RegisterRepositories();
        }

        private void RegisterRepositories()
        {
            // register custom repositories here
        }
    }
}