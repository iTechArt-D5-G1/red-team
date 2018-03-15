using System.Threading.Tasks;

namespace RedTeam.Repositories.Interfaces
{
    public interface IContext
    {
        Task<int> SaveChangesAsync();

        //Survey GetById(int id);
    }
}
