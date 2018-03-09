using System.Linq;

namespace RedTeam.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void SaveAsync();

        void Update(TEntity entity);

        void Delete(TEntity entity);

        TEntity GetById(int id);

        IQueryable<TEntity> GetQuery();
    }
}
