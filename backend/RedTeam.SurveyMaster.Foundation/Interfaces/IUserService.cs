using System.Linq;
using System.Threading.Tasks;
using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.SurveyMaster.Foundation.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> GetAllUsers();
    }
}
