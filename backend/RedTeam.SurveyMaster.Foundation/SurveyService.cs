using System.Threading.Tasks;
using RedTeam.Repositories.Interfaces;
using RedTeam.SurveyMaster.Foundation;
using RedTeam.SurveyMaster.Repositories;
using RedTeam.SurveyMaster.Repositories.Interfaces;

namespace RedTeam.SurveyMaster.Foundation
{
    public class SurveyService: ISurveyService
    {
        private readonly ISurveyMasterUnitOfWork _unitOfWork;
      

        public SurveyService(ISurveyMasterUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Survey> GetByIdAsync(int id)
        {
            var selectedSurveyById = await _unitOfWork
                .GetRepository<Survey>()
                .GetByIdAsync(id);
            return selectedSurveyById;
        }
    }
}
