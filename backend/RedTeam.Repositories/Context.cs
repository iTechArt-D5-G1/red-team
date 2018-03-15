using System.Data.Entity;
using System.Threading.Tasks;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.SurveyMaster.Repositories
{
    public abstract class Context: DbContext, IDbContext, IContext
    {
        private readonly IContext _context;

        private readonly IDbContext _db;

        public Context(IContext context, IDbContext db)
        {
            _db = db;
            _context = context;
        }

        public override DbSet<TEntity> Set<TEntity>() => _db.Set<TEntity>();

        public override Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        //public Survey GetById(int id)
        //{
        //    return Objects.Find(id);
        //}
    }
}
