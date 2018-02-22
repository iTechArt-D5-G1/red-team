using red_team.backend_infrastructure.Foundation;
using red_team.Repositories.Interfaces;

namespace red_team.Repositories
{
    public interface ISurveyRepository: IRepository<Survey>
    {
        new Survey GetByIdAsync(int id);
    }
}
