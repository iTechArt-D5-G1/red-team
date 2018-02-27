using red_team.backend_infrastructure.Foundation;
using System.Data.Entity;

namespace red_team.backend_infrastructure.Repositories
{
    public class SurveyContext: DbContext
    {
        public DbSet<Survey> Surveys { get; set; }
    }
}
