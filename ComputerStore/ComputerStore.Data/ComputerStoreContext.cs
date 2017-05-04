namespace ComputerStore.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using Models.EntityModels.Addresses;
    using Models.EntityModels.Orders;
    using Models.EntityModels.Products;
    using System.Data.Entity;

    public class ComputerStoreContext : IdentityDbContext<ApplicationUser>
    {
       
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderAddress> OrderAddresses { get; set; }


        public DbSet<CurrentOrder> CurrentOrders { get; set; }

        public DbSet<Comment> Comments { get; set; }









        public ComputerStoreContext()
            : base("name=ComputerStoreContext")
        {
        }

        public static ComputerStoreContext Create()
        {
            return new ComputerStoreContext();
        }

    }

   
}