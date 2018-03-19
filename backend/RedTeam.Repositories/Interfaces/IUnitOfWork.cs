using System.Threading.Tasks;

namespace RedTeam.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> Commit();

        void Rollback();

        void Dispose();
    }
}
