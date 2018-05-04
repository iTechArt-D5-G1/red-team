using System.Linq;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.Repositories.Interfaces;
using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.SurveyMaster.Foundation
{
    public class RoleService : IRoleService
    {
        private readonly ISurveyMasterUnitOfWork _unitOfWork;


        public RoleService(ISurveyMasterUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IQueryable<Role> GetAllRoles()
        {
            var roleRepository = _unitOfWork.GetRepository<Role>();
            return roleRepository.GetQuery();
        }
    }
}
