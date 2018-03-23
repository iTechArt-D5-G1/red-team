using System.Data.Entity;
using RedTeam.Repositories.Interfaces;
using RedTeam.SurveyMaster.Foundation;

namespace RedTeam.SurveyMaster.Repositories
{
    public class SurveyMasterDbContext : DbContext, IDbContext
    {
        private const string ConnectionStringName = "SurveyRepository";


        public DbSet<Survey> Surveys { get; set; }


        public SurveyMasterDbContext()
            : base(ConnectionStringName)
        {
            Configuration.LazyLoadingEnabled = false;
        }
    }
}