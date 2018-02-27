using RedTeam.BackendInfrastructure.Foundation;
using System.Data.Entity;

namespace RedTeam.BackendInfrastructure.Repositories.Interfaces
{
    public interface ISurveyContext
    {
        DbSet<Survey> Surveys { get; set; }
    }
}
