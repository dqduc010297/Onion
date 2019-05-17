﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AspNetCore.EntityFramework
{
    public class ConfigurationLoader<TContext> where TContext:DbContext
    {
        private ModelBuilder _modelBuilder;
        public ConfigurationLoader(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }
        public void Load()
        {
            var types = typeof(TContext).GetTypeInfo().Assembly.GetTypes();

            foreach (var t in types)
            {
                if(typeof(IEntityConfiguration).IsAssignableFrom(t)
                    && !t.GetTypeInfo().IsAbstract
                    && !t.GetTypeInfo().IsInterface)
                {
                    var configurationInstance = Activator.CreateInstance(t) as IEntityConfiguration;

                    configurationInstance.Configure(_modelBuilder);
                }
            }
        }
    }
}
