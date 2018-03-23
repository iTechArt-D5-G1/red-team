using System.Threading.Tasks;
using RedTeam.SurveyMaster.Foundation;

namespace RedTeam.SurveyMaster.Repositories.Interfaces
{
    public interface ISurveyService
    {
        Survey GetById(int id);
    }
}
