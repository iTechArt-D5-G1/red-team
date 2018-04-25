using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.SurveyMaster.Foundation.Interfaces
{
    public interface IUserService
    {
        User Add(User user);

        void Update(User user);

        void Delete(User user);

        Task<User> GetByIdAsync(int id);

        IQueryable<User> GetAllUsers();

        Task SaveChangesAsync();

    }
}
