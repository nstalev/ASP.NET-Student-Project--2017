namespace ComputerStore.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ComputerStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ComputerStoreContext context)
        {
            if (!context.Roles.Any(role => role.Name == "Customer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Customer");
                roleManager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "Administrator"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Administrator");
                roleManager.Create(role);
            }
        }
    }
}
