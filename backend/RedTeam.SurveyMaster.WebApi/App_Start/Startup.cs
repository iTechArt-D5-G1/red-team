using System.Configuration;
using System.Data.Entity;
using System.Reflection;
using Owin;
using Autofac;
using Microsoft.Owin;
using System.Web.Http;
using System.Web.Http.Dependencies;
using RedTeam.Repositories;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using RedTeam.Common;
using RedTeam.Common.Interfaсes;
using RedTeam.SurveyMaster.WebApi;
using RedTeam.Repositories.Interfaces;
using RedTeam.SurveyMaster.Foundation;
using RedTeam.SurveyMaster.Repositories;
using RedTeam.SurveyMaster.Foundation.Interfaces;
using RedTeam.SurveyMaster.Repositories.Interfaces;
using RedTeam.SurveyMaster.Repositories.Models;
using RedTeam.SurveyMaster.WebApi.AuthenticationFilters;
using RedTeam.SurveyMaster.WebApi.Controllers;

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
            _issuerUrl = _audienceUrl = applicationSettingsReader.GetValue("Url", typeof(string)) as string;
        }


        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            RegisterRoutes(config);
            ConfigureAutofac(config, app);
            ConfigureIdentityPerOwinContext(app, config.DependencyResolver);
            app.UseWebApi(config);
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

        private void ConfigureAutofac(HttpConfiguration configuration, IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterWebApiFilterProvider(configuration);
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<SurveyMasterUnitOfWork>().As<ISurveyMasterUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<SurveyService>().As<ISurveyService>().InstancePerLifetimeScope();
            builder.RegisterType<SurveyMasterDbContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthenticationTokenFilter>().AsWebApiAuthenticationFilterFor<ValueController>()
                .InstancePerLifetimeScope();

            builder.RegisterType<JwtTokenService>().As<ITokenService>()
                .WithParameter("securityKey", _securityKey)
                .WithParameter("exparationTime", _exparationTime)
                .WithParameter("issuerUrl", _issuerUrl)
                .WithParameter("audienceUrl", _audienceUrl)
                .InstancePerLifetimeScope();

            builder.RegisterType<SurveyMasterDbContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<UserStore<User>>().As<IUserStore<User>>().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationUserManager>().As<UserManager<User>>().InstancePerLifetimeScope();

            var container = builder.Build();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }

        private void ConfigureIdentityPerOwinContext(IAppBuilder app, IDependencyResolver dependencyResolver)
        {
            app.CreatePerOwinContext(() =>
                (SurveyMasterDbContext)dependencyResolver.GetService(typeof(SurveyMasterDbContext)));

            app.CreatePerOwinContext(() =>
                (UserManager<User>)dependencyResolver.GetService(typeof(UserManager<User>)));

            app.CreatePerOwinContext<RoleManager<Role>>((options, context) =>
            new RoleManager<Role>(
                new RoleStore<Role>(context.Get<SurveyMasterDbContext>())));
        }
    }
}
