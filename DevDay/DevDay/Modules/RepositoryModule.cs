
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;

namespace DevDay.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("DevDay.Repository"))
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();
        }
    }
}