using System.Threading.Tasks;
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


        public async Task<Role> GetByIdAsync(int id)
        {
            var roleRepository = _unitOfWork.GetRepository<Role>();
            var roleSelectedById = await roleRepository.GetByIdAsync(id);
            return roleSelectedById;
        }
    }
}
