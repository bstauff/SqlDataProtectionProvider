using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SqlDataProtectionProvider.Models;

namespace SqlDataProtectionProvider
{
    public class DataProtectionContext : DbContext
    {
        private readonly DbContextOptions _options;
        public DbSet<KeyDataEntry> KeyDataEntries { get; set; }

        public DataProtectionContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }
    }
}
