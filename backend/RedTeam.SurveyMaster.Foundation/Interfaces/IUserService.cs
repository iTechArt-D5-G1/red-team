using System.Linq;
using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.SurveyMaster.Foundation.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> GetAllUsers();
    }
}
