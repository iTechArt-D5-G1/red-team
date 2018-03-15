using RedTeam.SurveyMaster.Foundation;

namespace RedTeam.SurveyMaster.Repositories.Interfaces
{
    public interface IServise
    {
        Survey GetById(int id);
        void Save();
    }
}
