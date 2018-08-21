using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SqlDataProtectionProvider.Extensions
{
    public static class SqlDataProtectionProviderServicesExtensions
    {
        public static void AddSqlDataProtectionProviderContext(this IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            services.AddDbContext<DataProtectionContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
