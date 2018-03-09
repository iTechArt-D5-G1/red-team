using System.Threading.Tasks;
using RedTeam.SurveyMaster.Foundation;

namespace RedTeam.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task Save();

        void Dispose();

        Survey GetById(int id);
    }
}
