using RedTeam.Repositories;
using RedTeam.SurveyMaster.Repositories.Interfaces;

namespace RedTeam.SurveyMaster.Repositories
{
    public class UserUnitOfWork : UnitOfWork<UserDbContext>, IUserUnitOfWork
    {
        public UserUnitOfWork(UserDbContext dbContext) : base(dbContext)
        {
            RegisterRepositories();
        }

        private void RegisterRepositories()
        {
            //register reposytories
        }
    }
}
