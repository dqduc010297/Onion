using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AspNetCore.IoC.Autofact
{
    public class ServiceProviderOptions
    {
        protected ContainerBuilder builder;
        public ServiceProviderOptions(ContainerBuilder builder)
        {
            this.builder = builder;
        }
        public void AddAsImplementedInterface(Assembly assembly, bool preserveExistingDefaults = true)
        {
            var register = this.builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
            if (preserveExistingDefaults)
            {
                register.PreserveExistingDefaults();
            }
        }
        public void AddAsImplementInterface(Type handlerAssemblyMarkerType, bool preserveExistingDefaults = true)
        {
            AddAsImplementedInterface(handlerAssemblyMarkerType.GetTypeInfo().Assembly, preserveExistingDefaults);
        }
    }
}
