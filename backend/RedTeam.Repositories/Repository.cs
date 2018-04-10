using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly IDbContext Context;


        private readonly DbSet<TEntity> _dbSet;


        protected IQueryable<TEntity> DbSet => _dbSet;


        public Repository(IDbContext context)
        {
            Context = context;
            _dbSet = context.Set<TEntity>();
        }


        public virtual TEntity Create(TEntity entity)
        {
            return _dbSet.Add(entity);
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            var user = await _dbSet.FindAsync(id);

            return user;
        }

        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            var users = await _dbSet.ToListAsync();

            return users;
        }

        public virtual IQueryable<TEntity> GetQuery()
        {
            return _dbSet;
        }

        public virtual void Update(TEntity entity)
        {
            if (!_dbSet.Local.Contains(entity))
            {
                Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            if (!_dbSet.Local.Contains(entity))
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }
    }
}
