using System.Threading.Tasks;
using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.SurveyMaster.Foundation.Interfaces
{
    public interface ISurveyService
    {
        Task<Survey> GetByIdAsync(int id);
    }
}
