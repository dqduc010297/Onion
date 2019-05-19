﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructures.SeedData
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            string connectionString = (args.Length > 0 ? args[0] : null) ?? GetConnectionStringFromAppSetting();
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string is required");
            }
            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options);
        }

        private string GetConnectionStringFromAppSetting()
        {
            Console.WriteLine("Read connection string from appsettings.json");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                .SetBasePath(Directory.GetCurrentDirectory())
                                                .AddJsonFile("appsettings.json", optional: true)
                                                .Build();

            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}
