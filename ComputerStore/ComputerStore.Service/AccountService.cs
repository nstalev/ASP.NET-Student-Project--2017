using ComputerStore.Models.EntityModels;

namespace ComputerStore.Service
{
    public class AccountService : Service
    {
        public void CreateCustomer(string userId)
        {
            Customer customer = new Customer();
            ApplicationUser user = Context.Users.Find(userId);

            customer.User = user;
            Context.Customers.Add(customer);
            Context.SaveChanges();
        }
    }
}
