using RedTeam.BackendInfrastructure.Foundation;

namespace RedTeam.Repositories.Interfaces
{
    public interface IServise
    {
        Survey GetById(int id);
    }
}
