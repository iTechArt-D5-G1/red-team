using System.Data.Entity;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using RedTeam.BackendInfrastructure.Repositories;
using RedTeam.BackendInfrastructure.Repositories.Interfaces;
using RedTeam.BackendInfrastructure.WebApi;
using RedTeam.BackendInfrastructure.WebApi.Controllers;
using RedTeam.Repositories;
using RedTeam.Repositories.Interfaces;

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
            builder.RegisterType<ValueController>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(Context<>)).As(typeof(IContext<>));
            builder.RegisterType<Servise>().As<IServise>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        
            app.UseWebApi(config);  
            
            Database.SetInitializer(new SurveyDbInitializer());
        }
    }
}
