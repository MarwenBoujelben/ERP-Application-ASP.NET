using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class ContextDB : DbContext
    {

        public ContextDB() : base("myDB")
            {
            Database.SetInitializer<ContextDB>(new MigrateDatabaseToLatestVersion<ContextDB, EntrepriseRessourcesPlanning.Migrations.Configuration>());

        }

            public DbSet<Company> Company { get; set; }
            public DbSet<Provider> Providers { get; set; }
             public DbSet<Product> Products { get; set; }
             public DbSet<Invoice> Invoices { get; set; }
             public DbSet<Receipt> Receipts { get; set; }
             public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
            public DbSet<ProductOrder> ProductOrders { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<AccessClass> Accesses { get; set; }
        public DbSet<ProdImages> ProdImages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationUser> NotificationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
