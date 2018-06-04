using System.Threading.Tasks;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.Repositories.Interfaces;
using RedTeam.SurveyMaster.Repositories.Models;

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
            var surveyRepository = _unitOfWork.GetRepository<Survey>();
            var surveySelectedById = await surveyRepository.GetByIdAsync(id);
            return surveySelectedById;
        }
    }
}
