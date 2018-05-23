using RedTeam.SurveyMaster.Repositories;

namespace RedTeam.SurveyMaster.Foundation.Interfaces
{
    public interface IUserManagerFactory
    {
        UserManager GetUserManager();
    }
}
