using System.Linq;
using RedTeam.Repositories.Interfaces;
using RedTeam.SurveyMaster.Repositories.Interfaces;

namespace RedTeam.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        readonly IContext<TEntity> _db;

        public Repository(IContext<TEntity> db)
        {  
            _db = db;
        }

        TEntity IRepository<TEntity>.GetById(int id)
        {
            return _db.GetById(id);
        }

        public async void SaveAsync()
        {
            await _db.SaveChangesAsync();
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
