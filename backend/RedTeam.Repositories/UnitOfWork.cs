using System;
using RedTeam.Repositories.Interfaces;
using System.Threading.Tasks;

namespace RedTeam.Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : IDbContext
    {
        private IRepositoryProvider _repositoryProvider;
        private bool _disposed;


        protected IDbContext Context { get; private set; }


        public UnitOfWork(TContext dbContext)
        {
            _repositoryProvider = new RepositoryProvider<TContext>(dbContext);
            Context = dbContext;

            _disposed = false;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return _repositoryProvider.GetRepository<TEntity>();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void RegisterRepository<TEntity, TRepository>() where TEntity : class where TRepository : IRepository<TEntity>
        {
            _repositoryProvider.RegisterRepository<TEntity, TRepository>();
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _repositoryProvider?.Dispose();
                    Context?.Dispose();
                }

                _repositoryProvider = null;
                Context = null;
                _disposed = true;
            }
        }
    }
}
