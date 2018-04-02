using System.Threading.Tasks;
using RedTeam.Repositories.Interfaces;
using RedTeam.SurveyMaster.Foundation;
using RedTeam.SurveyMaster.Repositories.Interfaces;

namespace RedTeam.SurveyMaster.Repositories
{
    //TODO: should be in foundation projet
    public class SurveyService: ISurveyService
    {
        private readonly ISurveyMasterUnitOfWork _unitOfWork;

        private readonly IRepository<Survey> _repository;


        public SurveyService(ISurveyMasterUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Survey> GetById(int id)
        {
            var survey = await _unitOfWork.GetRepository<Survey>().GetByIdAsync(id);
            return survey;
        }
    }
}
