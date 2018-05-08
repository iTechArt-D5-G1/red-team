using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.Repositories.Models;
using RedTeam.SurveyMaster.Repositories.Interfaces;

namespace RedTeam.SurveyMaster.Foundation
{
    public class UserService : IUserService
    {
        private readonly ISurveyMasterUnitOfWork _unitOfWork;


        public UserService(ISurveyMasterUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IReadOnlyCollection<User>> GetAllUsersAsync()
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            var allUsers = await userRepository.GetAllAsync();
            return allUsers;
        }

        public async Task<bool> IsUserExistsAsync(string password, string login)
        {
            var users = await GetAllUsersAsync();
            return users.Any(u => u.Password == password && u.Username == login);
        }

        public async Task<User> GetUserAsync(string password, string login)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            var allUsers = await userRepository.GetAllAsync();
            return allUsers.FirstOrDefault(u => u.Password == password && u.Username == login);
        }
    }
}
