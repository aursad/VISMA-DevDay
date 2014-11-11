using System.Reflection;
using Autofac;

namespace DevDay.Modules
{
    public class ServiceModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(Assembly.Load("DevDay.Service"))
                      .Where(t => t.Name.EndsWith("Service"))
                      .AsImplementedInterfaces()
                      .InstancePerLifetimeScope();

        }

    }
}