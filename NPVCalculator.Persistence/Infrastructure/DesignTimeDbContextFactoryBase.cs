using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NPVCalculator.Persistence.Infrastructure
{
        /// <summary>
        /// Design time Db context factory base class
        /// </summary>
        public abstract class DesignTimeDbContextFactoryBase<TContext> :
            IDesignTimeDbContextFactory<TContext> where TContext : DbContext
        {
            private const string ConnectionStringName = "NPVCalculatorDatabase";
            private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

            /// <summary>
            /// Create Db context constructor
            /// </summary>
            /// <param name="args"></param>
            /// <returns>TContext</returns>
            public TContext CreateDbContext(string[] args)
            {
                var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}NPVCalculator.API", Path.DirectorySeparatorChar);
                return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
            }

            protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

            /// <summary>
            /// Method for creating context from appsettings
            /// </summary>
            /// <param name="basePath">Base path</param>
            /// <param name="environmentName">Environment name</param>
            /// <returns>TContext</returns>
            private TContext Create(string basePath, string environmentName)
            {

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.Local.json", optional: true)
                    .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                    .AddEnvironmentVariables()
                    .Build();

                var connectionString = configuration.GetConnectionString(ConnectionStringName);

                return Create(connectionString);
            }

            /// <summary>
            /// Method for creating context from connection string
            /// </summary>
            /// <param name="connectionString">Connection string</param>
            /// <returns>TContext</returns>
            private TContext Create(string connectionString)
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
                }

                Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

                var optionsBuilder = new DbContextOptionsBuilder<TContext>();

                optionsBuilder.UseSqlServer(connectionString);

                return CreateNewInstance(optionsBuilder.Options);
            }
        }
}
