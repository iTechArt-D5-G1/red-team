using Microsoft.AspNet.Identity;
using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.SurveyMaster.Foundation
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store)
            : base(store)
        {
        }
    }
}
