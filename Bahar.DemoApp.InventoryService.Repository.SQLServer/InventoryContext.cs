using Bahar.DemoApp.InventoryService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bahar.DemoApp.InventoryService.Repository.SQLServer
{
    public class InventoryContext : DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }
        public InventoryContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                 //    .UseLoggerFactory(ConsoleLoggerFactory).EnableSensitiveDataLogging()
                 .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InventoryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
                 builder => builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null));
            }
        }
    }

}
