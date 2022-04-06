using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using DbModelsLib;

namespace DbContextLib
{
    public class SeidoDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public SeidoDbContext() { }
        public SeidoDbContext(DbContextOptions options) : base(options)
        { }

   
        //Used only for CodeFirst Database Migration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = DBConnection.ConfigurationRoot.GetConnectionString("SQLite_seidowebservice");
                optionsBuilder.UseSqlite(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
