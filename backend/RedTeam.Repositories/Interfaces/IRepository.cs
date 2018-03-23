using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedTeam.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Update(TEntity entity);

        void Delete(TEntity entity);

        TEntity Create(TEntity entity);

        Task<TEntity> GetByIdAsync(int id);

        Task<IReadOnlyCollection<TEntity>> GetAllAsync();

        IQueryable<TEntity> GetQuery();
    }
}
