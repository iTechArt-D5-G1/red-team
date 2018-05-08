using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.SurveyMaster.Foundation.Interfaces
{
    public interface IUserService
    {
        Task<IReadOnlyCollection<User>> GetAllUsersAsync();

        Task<bool> IsUserExistsAsync(string password, string login);

        Task<User> GetUserAsync(string password, string login);


    }
}
