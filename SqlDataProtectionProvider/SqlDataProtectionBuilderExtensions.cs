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

            builder.Services.AddDbContext<DataProtectionContext>(options => options.UseSqlServer(sqlConnectionString));

            builder.Services.AddScoped<SqlDataProtectionProvider>();

            builder.Services.AddScoped<IConfigureOptions<KeyManagementOptions>>(services =>
            {
                var loggerFactory = services.GetService<ILoggerFactory>() ?? NullLoggerFactory.Instance;
                var protectionProvider = services.GetRequiredService<SqlDataProtectionProvider>();

                return new ConfigureOptions<KeyManagementOptions>(options =>
                {
                    options.XmlRepository = protectionProvider;
                });
            });

            return builder;
        }
    }
}
