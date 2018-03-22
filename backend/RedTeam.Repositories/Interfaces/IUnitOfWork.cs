using System;
using System.Threading.Tasks;

namespace RedTeam.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Commit();

        void Rollback();
    }
}
