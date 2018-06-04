using System;
using System.Collections.Generic;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.Repositories
{
    public class RepositoryProvider<TContext> : IRepositoryProvider where TContext : IDbContext
    {
        private readonly IDictionary<Type, Type> _entityTypeToCustomRepositoryTypeMappings;
        private readonly Dictionary<Type, object> _repositories;
        private bool _disposed;


        protected IDbContext Context { get; private set; }


        public RepositoryProvider(TContext dbContext)
        {
            Context = dbContext;
            _repositories = new Dictionary<Type, object>();
            _entityTypeToCustomRepositoryTypeMappings = new Dictionary<Type, Type>();
            _disposed = false;
        }


        IRepository<TEntity> IRepositoryProvider.GetRepository<TEntity>()
        {
            return (IRepository<TEntity>)GetOrCreateRepository<TEntity>();
        }

        void IRepositoryProvider.RegisterRepository<TEntity, TRepository>()
        {
            RegisterRepository<TEntity, TRepository>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void RegisterRepository<TEntity, TRepository>()
        {
            _entityTypeToCustomRepositoryTypeMappings.Add(typeof(TEntity), typeof(TRepository));
        }

        private object GetOrCreateRepository<TEntity>() where TEntity : class
        {
            if (_repositories.TryGetValue(typeof(TEntity), out var cachedRepository))
            {
                return cachedRepository;
            }

            var repository = _entityTypeToCustomRepositoryTypeMappings.TryGetValue(typeof(TEntity), out var repositoryType)
                ? (Repository<TEntity>)Activator.CreateInstance(repositoryType, Context)
                : new Repository<TEntity>(Context);
            _repositories.Add(typeof(TEntity), repository);

            return repository;
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context?.Dispose();
                }

                Context = null;
                _disposed = true;
            }
        }
    }
}