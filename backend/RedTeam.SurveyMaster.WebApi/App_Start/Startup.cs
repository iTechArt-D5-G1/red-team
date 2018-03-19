using Owin;
using Autofac;
using Microsoft.Owin;
using System.Web.Http;
using System.Data.Entity;
using RedTeam.Repositories;
using Autofac.Integration.WebApi;
using RedTeam.SurveyMaster.WebApi;
using RedTeam.Repositories.Interfaces;
using RedTeam.SurveyMaster.Repositories;
using RedTeam.SurveyMaster.WebApi.Controllers;
using RedTeam.SurveyMaster.Repositories.Interfaces;

[assembly: OwinStartup(typeof(Startup))]

namespace RedTeam.SurveyMaster.WebApi
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
            builder.RegisterType<ValueController>().InstancePerRequest(); ;
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)); 
            builder.RegisterType<Servise>().As<IServise>();
            builder.RegisterType<Context>().As<IContext>();
            builder.RegisterType<DbContext>().AsSelf();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        
            app.UseWebApi(config);  
            
        }
    }
}
