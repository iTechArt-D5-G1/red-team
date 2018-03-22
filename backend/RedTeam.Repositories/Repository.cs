using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        private readonly IContext _context;

        private readonly IDbContext _dbContext;


        public Repository(IDbContext dbContext, IContext context)
        {
            _context = context;
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveAsync();
        }

        public void Delete(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TEntity> GetQuery()
        {
            throw new System.NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
