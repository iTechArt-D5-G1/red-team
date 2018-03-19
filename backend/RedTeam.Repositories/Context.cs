using System.Data.Entity;
using System.Threading.Tasks;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.Repositories
{
    public class Context: DbContext, IContext
    {
        private readonly DbContext _dbContext;

        public Context(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}