using System.Data.Entity;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using RedTeam.BackendInfrastructure.Repositories;
using RedTeam.BackendInfrastructure.WebApi;
using RedTeam.BackendInfrastructure.WebApi.Controllers;
using RedTeam.Repositories;

[assembly: OwinStartup(typeof(Startup))]

namespace RedTeam.BackendInfrastructure.WebApi
{
    public sealed class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );
            builder.RegisterGeneric(typeof(Repository)).AsSelf();
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
