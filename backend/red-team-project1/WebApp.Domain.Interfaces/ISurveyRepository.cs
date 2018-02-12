using WebApp.Domain.Core;

namespace WebApp.Domain.Interfaces
{
    public interface ISurveyRepository
    {
        Survey GetSurveyById(int id);    
    }
}
