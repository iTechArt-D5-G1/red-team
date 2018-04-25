using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.Repositories.Models;
using RedTeam.SurveyMaster.Repositories.Interfaces;
namespace RedTeam.SurveyMaster.Foundation
{
    public class UserService : IUserService
    {
        private readonly IUserUnitOfWork _unitOfWork;


        public UserService(IUserUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User Add(User user)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            return userRepository.Create(user);
        }

        public void Update(User user)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            userRepository.Update(user);
        }

        public void Delete(User user)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            userRepository.Delete(user);
        }

        public Task<User> GetByIdAsync(int id)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            return userRepository.GetByIdAsync(id);
        }

        public IQueryable<User> GetAllUsers()
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            return userRepository.GetQuery();
        }

        public Task SaveChangesAsync()
        {
            return _unitOfWork.SaveAsync();
        }
    }
}
