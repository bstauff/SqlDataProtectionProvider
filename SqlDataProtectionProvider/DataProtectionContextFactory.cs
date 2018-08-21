using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SqlDataProtectionProvider
{
    public class DataProtectionContextFactory : IDesignTimeDbContextFactory<DataProtectionContext>
    {
        public DataProtectionContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataProtectionContext>();

            optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=DataProtectionKeys;Integrated Security=true;");

            return new DataProtectionContext(optionsBuilder.Options);
        }
    }
}
