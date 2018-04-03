using System.Threading.Tasks;

namespace RedTeam.SurveyMaster.Repositories.Interfaces
{
    public interface ISurveyService
    {
        Task<Survey> GetByIdAsync(int id);
    }
}
