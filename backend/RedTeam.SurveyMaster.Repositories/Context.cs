using System.Data.Entity;
using System.Threading.Tasks;
using RedTeam.SurveyMaster.Repositories.Interfaces;

namespace RedTeam.SurveyMaster.Repositories
{
    public class Context<T>: DbContext, IContext<T> where T: class
    {
        readonly IContext<T> _db;

        public DbSet<T> Objects { get; set; }

        public Context(IContext<T> db)
        {
            _db = db;
        }

        public override Task<int> SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }

        public T GetById(int id)
        {
            return _db.Objects.Find(id);
        }
    }
}
