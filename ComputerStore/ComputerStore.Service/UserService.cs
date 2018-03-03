using System.Linq;
using ComputerStore.Models.ViewModels.User;
using ComputerStore.Models.EntityModels;
using ComputerStore.Models.BindingModels.Orders;
using ComputerStore.Models.EntityModels.Addresses;
using AutoMapper;
using ComputerStore.Models.ViewModels.Addresses;
using ComputerStore.Models.BindingModels.Addresses;
using System.Collections.Generic;
using ComputerStore.Models.ViewModels.Orders;
using ComputerStore.Models.EntityModels.Orders;

namespace ComputerStore.Service
{
    public class UserService : Service
    {
        public UserProfileVM GetUserProfile(string userName)
        {
            ApplicationUser user = Context.Users.FirstOrDefault(user1 => user1.UserName == userName);
          //  Customer customer = Context.Customers.FirstOrDefault(cust => cust.User.UserName == userName);

            UserProfileVM vm = Mapper.Map<ApplicationUser, UserProfileVM>(user);


            return vm;
        }

        public void AddAddress(AddAddressBM bind, string userName)
        {
            Customer customer = Context.Customers.FirstOrDefault(cust => cust.User.UserName == userName);

            Address address = Mapper.Map<AddAddressBM, Address>(bind);

            customer.Addresses.Add(address);
            Context.SaveChanges();
        }

        public DetailsAddressVm GetDetailAddressVm(int id)
        {
            Address address = Context.Addresses.Find(id);

            DetailsAddressVm vm = Mapper.Map<Address, DetailsAddressVm>(address);

            return vm;
        }

        public EditAddressVm GetEditAddressVm(int id)
        {
            Address address = Context.Addresses.Find(id);

            EditAddressVm vm = Mapper.Map<Address, EditAddressVm>(address);

            return vm;

        }

        public void EditAddress(EditAddressBM bind)
        {
            Address address = Context.Addresses.Find(bind.Id);

            address.City = bind.City;
            address.Streat = bind.Streat;
            address.PostCode = bind.PostCode;
            address.PhoneNumber = bind.PhoneNumber;
            Context.SaveChanges();

        }



        public void DeleteAddress(int AddressId)
        {
            Address address = Context.Addresses.Find(AddressId);

            Context.Addresses.Remove(address);
            Context.SaveChanges();
        }

        public DeleteAddressVm GetDeleteAddressVm(int id)
        {
            Address address = Context.Addresses.Find(id);

            DeleteAddressVm vm = Mapper.Map<Address, DeleteAddressVm>(address);

            return vm;
        }

        public IEnumerable<AddressVM> GetAllAddressVm(string userName)
        {
            Customer customer = Context.Customers.FirstOrDefault(cust => cust.User.UserName == userName);

            IEnumerable<Address> addresses = customer.Addresses;

            IEnumerable<AddressVM> vms = Mapper.Map<IEnumerable<Address>, IEnumerable<AddressVM>>(addresses);

            return vms;
        }

        public IEnumerable<AllOrdersVm> GetAllOrdersVm(string userName)
        {
            Customer customer = Context.Customers.FirstOrDefault(cust => cust.User.UserName == userName);

            IEnumerable<Order> myOrders = customer.OrdersBuyer.OrderByDescending(order => order.OrderDate);

            IEnumerable<AllOrdersVm> vms = Mapper.Map<IEnumerable<Order>, IEnumerable<AllOrdersVm>>(myOrders);

            return vms;
        }

        public DetailsOrderVm GetDetailsOrderVm(int id, string userName)   
        {
            Order order = Context.Orders.FirstOrDefault(order1 =>order1.Id == id);

            Customer customer = Context.Customers.FirstOrDefault(cust => cust.User.UserName == userName);

          //  Order order2 = customer.OrdersBuyer.FirstOrDefault(order1 => order1.Id == id);


            OrderAddress address = order.Address;

            AddressVM addressVm = Mapper.Map<OrderAddress, AddressVM>(address);

            DetailsOrderVm vm = Mapper.Map<Order, DetailsOrderVm>(order);

            vm.DeliveryAddress = addressVm;

            return vm;

            
        }
    }
}
