using red_team.backend_infrastructure.Foundation;

namespace red_team.Repositories.Interfaces
{
    public interface ISurveyRepository: IRepository<Survey>
    {
        new Survey GetByIdAsync(int id);
    }
}
