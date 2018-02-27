using System.Data.Entity;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using RedTeam.BackendInfrastructure.Repositories;
using RedTeam.BackendInfrastructure.WebApi.WebApi.Controllers;
using RedTeam.Repositories;

[assembly: OwinStartup(typeof(RedTeam.BackendInfrastructure.WebApi.App_Start.Startup))]

namespace RedTeam.BackendInfrastructure.WebApi.App_Start
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
            builder.RegisterGeneric(typeof(Repository<>)).AsSelf();
            builder.RegisterType<ValueController>();
            builder.RegisterType<UnitOfWork>().AsSelf();
            builder.RegisterType<SurveyContext>().AsSelf();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        
            app.UseWebApi(config);  
            
            Database.SetInitializer(new SurveyDbInitializer());
        }
    }
}
