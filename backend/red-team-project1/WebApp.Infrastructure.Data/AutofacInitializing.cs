using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http.SelfHost;
using WebApp.Domain.Interfaces;

namespace WebApp.Infrastructure.Data
{
    public class AutofacInitializing
    {

        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            var config = new HttpSelfHostConfiguration("http://localhost:62251/");
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();
            builder.Register(c => new SurveyRepository()).As<ISurveyRepository>();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);   
        }
    }
}