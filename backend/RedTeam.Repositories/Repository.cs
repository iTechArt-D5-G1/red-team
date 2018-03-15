using System.Linq;
using System.Threading.Tasks;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IContext _db;

        public Repository(IContext db)
        {  
            _db = db;
        }

        //TEntity IRepository<TEntity>.GetById(int id)
        //{
        //    _db.Set()
        //    return _db.GetById(id);
        //}

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
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

        public TEntity GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
