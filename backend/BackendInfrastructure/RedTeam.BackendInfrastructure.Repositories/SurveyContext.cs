using RedTeam.BackendInfrastructure.Foundation;
using System.Data.Entity;

namespace RedTeam.BackendInfrastructure.Repositories
{
    public class SurveyContext: DbContext
    {
        public DbSet<Survey> Surveys { get; set; }
    }
}
