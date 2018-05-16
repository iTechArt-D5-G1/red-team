using System.Configuration;
using Owin;
using Autofac;
using Microsoft.Owin;
using System.Web.Http;
using RedTeam.Repositories;
using Autofac.Integration.WebApi;
using RedTeam.Common;
using RedTeam.Common.Interfaсes;
using RedTeam.SurveyMaster.WebApi;
using RedTeam.Repositories.Interfaces;
using RedTeam.SurveyMaster.Foundation;
using RedTeam.SurveyMaster.Repositories;
using RedTeam.SurveyMaster.WebApi.Controllers;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.Repositories.Interfaces;
using RedTeam.SurveyMaster.WebApi.AuthenticationFilters;

[assembly: OwinStartup(typeof(Startup))]

namespace RedTeam.SurveyMaster.WebApi
{
    public sealed class Startup
    {

        private readonly string _securityKey;

        private readonly int _exparationTime;

        private readonly string _issuerUrl;

        private readonly string _audienceUrl;


        public Startup()
        {
            var applicationSettingsReader = new AppSettingsReader();

            _securityKey = applicationSettingsReader.GetValue("SecurityKey", typeof(string)) as string;
            _exparationTime = (int)applicationSettingsReader.GetValue("ExpirationTokenTime", typeof(int));
            _issuerUrl = _audienceUrl = "http://localhost:12345";
        }


        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            app.Use<GlobalExceptionMiddleware>();
            RegisterRoutes(config);
            ConfigureAutofac(config);
            config.Filters.Add(new AuthenticationTokenFilter(new JwtTokenService(_securityKey, _exparationTime, _issuerUrl, _audienceUrl)));
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

            builder.RegisterType<JwtTokenService>().As<ITokenService>()
                .WithParameter("securityKey", _securityKey)
                .WithParameter("exparationTime", _exparationTime)
                .WithParameter("issuerUrl", _issuerUrl)
                .WithParameter("audienceUrl", _audienceUrl);

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
