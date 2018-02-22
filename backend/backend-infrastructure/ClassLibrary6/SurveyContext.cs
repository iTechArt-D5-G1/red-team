using ClassLibrary6.Interfaces;
using red_team.backend_infrastructure.Foundation;
using System.Data.Entity;

namespace ClassLibrary6
{
    public class SurveyContext: DbContext, ISurveyContext
    {
        public DbSet<Survey> Surveys { get; set; }
    }
}
