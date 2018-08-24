using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SqlDataProtectionProvider.Models;

namespace SqlDataProtectionProvider
{
    public partial class DataProtectionContext : DbContext
    {
        public DbSet<KeyData> KeyData { get; set; }

        public DataProtectionContext()
        {
        }

        public DataProtectionContext(DbContextOptions<DataProtectionContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KeyData>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
        }
    }
}
