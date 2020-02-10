using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Service_Tests
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
                .Where(t => t.Name.EndsWith("Controller"))
                .AsImplementedInterfaces();

            return builder.Build();
        }
    }
}
