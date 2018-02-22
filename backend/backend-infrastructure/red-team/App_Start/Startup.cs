using System.Data.Entity;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using red_team.backend_infrastructure.Repositories;
using red_team.backend_infrastructure.Repositories.Interfaces;
using red_team.backend_infrastructure.WebApi.Controllers;
using red_team.Repositories;

[assembly: OwinStartup(typeof(red_team.backend_infrastructure.WebApi.App_Start.Startup))]

namespace red_team.backend_infrastructure.WebApi.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            builder.RegisterType<ValueController>();
            builder.RegisterType<SurveyContext>().As<SurveyContext>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseWebApi(config);  
            
            Database.SetInitializer(new SurveyDbInitializer());
        }
    }
}
