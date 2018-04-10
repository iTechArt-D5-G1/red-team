using Owin;
using Autofac;
using Microsoft.Owin;
using System.Web.Http;
using RedTeam.Repositories;
using Autofac.Integration.WebApi;
using RedTeam.SurveyMaster.WebApi;
using RedTeam.Repositories.Interfaces;
using RedTeam.SurveyMaster.Foundation;
using RedTeam.SurveyMaster.Repositories;
using RedTeam.SurveyMaster.WebApi.Controllers;
using RedTeam.SurveyMaster.Foundation.Interfaces;
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
            app.Use<GlobalExceptionMiddleware>();
            RegisterRoutes(config);
            ConfigureAutofac(builder);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseWebApi(config);
        }

        private void ConfigureAutofac(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType<ValueController>();
            builder.RegisterType<SurveyMasterUnitOfWork>().As<ISurveyMasterUnitOfWork>();
            builder.RegisterType<SurveyService>().As<ISurveyService>();
            builder.RegisterType<SurveyMasterDbContext>().AsSelf();
        }

        private void RegisterRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );
        }
    }
}
