using System.Threading.Tasks;

namespace RedTeam.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();

        void Rollback();

        void Dispose();
    }
}
