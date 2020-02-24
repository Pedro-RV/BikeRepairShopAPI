using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Sale_Service.App_Start
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Sale_Service)));

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Sale_Bussiness)))
                .Where(t => t.Name.EndsWith("Bussiness"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Sale_Data)))
                .Where(t => t.Name.EndsWith("Repository") || t.Name.EndsWith("Provider"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Sale_Helper)))
                .Where(t => t.Name.EndsWith("Controller") || t.Name.EndsWith("Provider"))
                .AsImplementedInterfaces();

            return builder.Build();
        }
    }
}