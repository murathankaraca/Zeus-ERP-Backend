using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using ZeusERP.Core.Utilities;
using ZeusERP.Entities.Concrete;

namespace ZeusERP.DataAccess.Contexts
{
    public class ZeusContext : DbContext
    {
        public string ConnectionString { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<BillOfMaterials> BillOfMaterials { get; set; }
        public DbSet<BillOfMaterialsComponent> BillOfMaterialsComponents { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryOperation> DeliveryOperations { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Replenishment> Replenishments { get; set; }
        public DbSet<Manufacturing> ManufacturingOrders { get; set; }
        public DbSet<ManufacturingComponent> ManufacturingOrderComponents { get; set; }
        public DbSet<Unbuild> Unbuilds { get; set; }

        // public DbSet<InventoryAdjustment> InventoryAdjustments { get; set; }
        
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Route> Routes { get; set; }
        // PLM

        public DbSet<EngineeringChangeOrder> ECOS { get; set; }
        public DbSet<ECOTag> ECOTags { get; set; }
        public DbSet<ECOType> ECOTypes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            try
            {
                ConnectionString = WebConfig.GetConfigItem("SaffetDB").Result;
                Console.WriteLine(ConnectionString);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public ZeusContext()
        {

        }
        public ZeusContext(DbContextOptions<ZeusContext> options) : base(options)
        {
           
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
