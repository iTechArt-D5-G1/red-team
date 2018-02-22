namespace red_team.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetByIdAsync(int id);
    }
}
