using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.SurveyMaster.Repositories
{
    public class UserManager : UserManager<User>
    {
        public UserManager(IUserStore<User> store)
            : base(store)
        {
        }


        public static UserManager Create(
            IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            var manager = new UserManager(
                new UserStore<User>(context.Get<SurveyMasterDbContext>()));

            return manager;
        }
    }
}
