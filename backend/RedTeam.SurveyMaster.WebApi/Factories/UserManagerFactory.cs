using System.Web;
using Microsoft.AspNet.Identity.Owin;
using RedTeam.SurveyMaster.Foundation;
using RedTeam.SurveyMaster.Foundation.Interfaces;

namespace RedTeam.SurveyMaster.WebApi.Factories
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
