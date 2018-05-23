using System.Web;
using Microsoft.AspNet.Identity.Owin;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.Repositories;

namespace RedTeam.SurveyMaster.Foundation
{
    public class UserManagerFactory : IUserManagerFactory
    {
        public UserManager GetUserManager()
        {
            var userManager =  HttpContext.Current.GetOwinContext().GetUserManager<UserManager>();
            return userManager;
        }
    }
}
