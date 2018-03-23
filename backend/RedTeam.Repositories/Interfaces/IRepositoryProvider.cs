using System;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.Repositories
{
    public interface IRepositoryProvider : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        void RegisterRepository<TEntity, TRepository>() where TEntity : class where TRepository : IRepository<TEntity>;
    }
}