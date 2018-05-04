using Owin;
using Autofac;
using Microsoft.Owin;
using System.Web.Http;
using RedTeam.Repositories;
using Autofac.Integration.WebApi;
using RedTeam.Common.Token.Concrete_Factories;
using RedTeam.Common.Token.Concrete_Token_Creators;
using RedTeam.Common.Token.Concrete_Validators;
using RedTeam.Common.Token.Interfases;
using RedTeam.SurveyMaster.WebApi;
using RedTeam.Repositories.Interfaces;
using RedTeam.SurveyMaster.Foundation;
using RedTeam.SurveyMaster.Repositories;
using RedTeam.SurveyMaster.WebApi.Controllers;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.Repositories.Interfaces;
using RedTeam.SurveyMaster.WebApi.Authentication_Filters;

[assembly: OwinStartup(typeof(Startup))]

namespace RedTeam.SurveyMaster.WebApi
{
    public sealed class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            app.Use<GlobalExceptionMiddleware>();
            RegisterRoutes(config);
            ConfigureAutofac(config);
            config.Filters.Add(new AuthenticationTokenFilter(new JwtTokenFactory()));
            app.UseWebApi(config);
        }

        private void ConfigureAutofac(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<ValueController>();
            builder.RegisterType<AuthController>();

            builder.RegisterType<SurveyMasterUnitOfWork>().As<ISurveyMasterUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<SurveyService>().As<ISurveyService>().InstancePerLifetimeScope();
            builder.RegisterType<SurveyMasterDbContext>().AsSelf().InstancePerLifetimeScope();
            
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerLifetimeScope();

            builder.RegisterType<JwtTokenFactory>().As<ITokenFactory>();
            builder.RegisterType<JwtTokenValidator>().As<ITokenValidator>();
            builder.RegisterType<JwtTokenCreator>().As<ITokenCreator>();

            var container = builder.Build();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
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
