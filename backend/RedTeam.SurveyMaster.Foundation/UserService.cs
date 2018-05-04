using System.Linq;
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


        public IQueryable<User> GetAllUsers()
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            return userRepository.GetQuery();
        }
    }
}
