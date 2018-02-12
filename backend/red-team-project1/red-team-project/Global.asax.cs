using System.Data.Entity;
using System.Web.Http;
using WebApp.Infrastructure.Data;


namespace red_team_project
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new SurveyDbInitializer());
            GlobalConfiguration.Configure(WebRouting.Register);
            AutofacInitializing.ConfigureContainer();
        }
    }
}
