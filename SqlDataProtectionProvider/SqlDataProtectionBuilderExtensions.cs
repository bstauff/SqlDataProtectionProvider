using System;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace SqlDataProtectionProvider
{
    public static class SqlDataProtectionBuilderExtensions
    {
        public static IDataProtectionBuilder PersistKeysToSqlServer(this IDataProtectionBuilder builder, string sqlConnectionString)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (string.IsNullOrEmpty(sqlConnectionString))
            {
                throw new ArgumentNullException(nameof(sqlConnectionString));
            }

            
            builder.Services.Configure<KeyManagementOptions>(options =>
            {
                //Set up dbcontext options to use sql server and give it the connection string
                var dbOptionsBuilder = new DbContextOptionsBuilder<DataProtectionContext>();
                dbOptionsBuilder.UseSqlServer(sqlConnectionString);
                var dbContextOptions = dbOptionsBuilder.Options;

                options.XmlRepository = new SqlDataProtectionProvider(dbContextOptions);
            });

            return builder;
        }
    }
}
