using System.Threading.Tasks;
using RedTeam.BackendInfrastructure.Foundation;

namespace RedTeam.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task Save();

        void Dispose();

        Survey GetById(int id);
    }
}
