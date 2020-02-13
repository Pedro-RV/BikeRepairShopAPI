using Autofac;
using Supplier_Bussiness;
using Supplier_Bussiness.Interfaces;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Data.Interfaces;
using Supplier_Helper.ExceptionController;
using Supplier_Service.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Supplier_Service
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Supplier_Service)));

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Supplier_Bussiness)))
                .Where(t => t.Name.EndsWith("Bussiness"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Supplier_Data)))
                .Where(t => t.Name.EndsWith("Repository") || t.Name.EndsWith("Provider"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Supplier_Helper)))
                .Where(t => t.Name.EndsWith("Controller") || t.Name.EndsWith("Provider"))
                .AsImplementedInterfaces();

            return builder.Build();
        }
    }
}