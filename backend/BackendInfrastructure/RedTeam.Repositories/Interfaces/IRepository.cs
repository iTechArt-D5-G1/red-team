using System.Linq;

namespace RedTeam.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Update(TEntity entity);

        void Delete(TEntity entity);

        TEntity GetByIdAsync(int id);

        IQueryable<TEntity> GetQuery();
    }
}
