using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using DevDay.Modules;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DevDay
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());

            //Autofac Configuration
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EFModule());

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}