using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tests
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Supplier_Data)))
                .Where(t => t.Name.EndsWith("Repository") || t.Name.EndsWith("Provider"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Supplier_Helper)))
                .Where(t => t.Name.EndsWith("Controller"))
                .AsImplementedInterfaces();

            return builder.Build();
        }
    }
}
