using System.Data.Entity;

namespace RedTeam.Repositories.Interfaces
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity: class;
        
    }
}
