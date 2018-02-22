using red_team.backend_infrastructure.Foundation;
using System.Data.Entity;

namespace red_team.backend_infrastructure.Repositories.Interfaces
{
    public interface ISurveyContext
    {
        DbSet<Survey> Surveys { get; set; }
    }
}
