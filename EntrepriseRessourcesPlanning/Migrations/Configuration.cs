namespace EntrepriseRessourcesPlanning.Migrations
{
    using EntrepriseRessourcesPlanning.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntrepriseRessourcesPlanning.Models.ContextDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntrepriseRessourcesPlanning.Models.ContextDB context)
        {
            //  This method will be called after migrating to the latest version.


            /*var accesses = context.Accesses;
            List<AccessClass> ListAccesses = new List<AccessClass>();
            foreach(var acc in accesses)
            {
                ListAccesses.Add(acc);
            }
            // Create the administrator user
            var administrator = new User
            {
                UserCIN = "22222222",
                Name = "Administrator",
                Username = "admin",
                Password = "Admin123", // Note: This should be properly hashed and secured in a real application
                Accesses = ListAccesses
            };

            // Assign all access levels to the administrator
            


            // Add the administrator user to the context
            context.Users.Add(administrator);

            // Save changes to the database
            context.SaveChanges();*
            /*var access = new AccessClass
            {
                Acc_Role = "AddingReceipt"
            };
            context.Accesses.Add(access);
            

            AccessClass accessDB = context.Accesses.FirstOrDefault(acc => (acc.Acc_Role == "AddingReceipt"));
            if (accessDB != null)
            {
                var userDB = context.Users.Include("Accesses").FirstOrDefault(u => u.UserCIN == "22222222");
                
                userDB.Accesses.Add(accessDB);
                context.SaveChanges();
            }
            */
            
        }

    }
    }

