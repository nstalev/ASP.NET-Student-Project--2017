using ComputerStore.Models.BindingModels.Notebook;
using ComputerStore.Models.EntityModels.Products;
using AutoMapper;
using ComputerStore.Models.BindingModels.DeskComputers;
using ComputerStore.Models.ViewModels.Orders;
using System.Collections.Generic;
using ComputerStore.Models.EntityModels.Orders;
using System.Linq;
using ComputerStore.Models.EntityModels.Addresses;
using ComputerStore.Models.EntityModels;
using ComputerStore.Models.ViewModels.Addresses;

namespace ComputerStore.Service
{
    public class AdminService : Service
    {
        public void AddNotebookFromBind(AddNotebookBm bind)
        {
            Notebooks notebook = Mapper.Map<AddNotebookBm, Notebooks>(bind);

            Context.Items.Add(notebook);
            Context.SaveChanges();
        }



        public void AddDeskComputerBind(AddDeskCompBM bind)
        {
            DeskComputers deskComputer = Mapper.Map<AddDeskCompBM, DeskComputers>(bind);
            Context.Items.Add(deskComputer);
            Context.SaveChanges();
        }



        public IEnumerable<AllOrdersVm> GetAllInActiveOrdersVM()
        {
            IEnumerable<Order> activeOrders = Context.Orders.Where(order => order.Status == Models.Enums.Status.Active);

            IEnumerable<AllOrdersVm> vms = Mapper.Map<IEnumerable<Order>, IEnumerable<AllOrdersVm>>(activeOrders);

            return vms;
        }



        public IEnumerable<AllOrdersVm> GetAllInProgressOrdersVM()
        {
            IEnumerable<Order> InProgressOrders = Context.Orders.Where(order => order.Status == Models.Enums.Status.InProgress);

            IEnumerable<AllOrdersVm> vms = Mapper.Map<IEnumerable<Order>, IEnumerable<AllOrdersVm>>(InProgressOrders);

            return vms;
        }



        public IEnumerable<AllOrdersVm> GetAllCompletedOrdersVM()
        {
            IEnumerable<Order> completedOrders = Context.Orders.Where(order => order.Status == Models.Enums.Status.Completed);

            IEnumerable<AllOrdersVm> vms = Mapper.Map<IEnumerable<Order>, IEnumerable<AllOrdersVm>>(completedOrders);

            return vms;
        }



        public DetailsStoreOrderVm GetDetailsStoreOrderVm(int id)
        {
            Order order = Context.Orders.FirstOrDefault(order1 => order1.Id == id);

            Customer customer = order.Buyer;


            OrderAddress address = order.Address;

            AddressVM addressVm = Mapper.Map<OrderAddress, AddressVM>(address);

            DetailsStoreOrderVm vm = Mapper.Map<Order, DetailsStoreOrderVm>(order);

            vm.DeliveryAddress = addressVm;

            return vm;


        }



        public void ChangeStatusToInProgress(int id)
        {
            Order order = Context.Orders.Find(id);

            order.Status = Models.Enums.Status.InProgress;
            Context.SaveChanges();

        }


        public void ChangeStatusToCompleted(int id)
        {
            Order order = Context.Orders.Find(id);

            order.Status = Models.Enums.Status.Completed;
            Context.SaveChanges();
        }

        public CountOrdersVM GetCountOrdersVM()
        {

            int activeOrders = Context.Orders.Count(order => order.Status == Models.Enums.Status.Active);
            int inProgressOrders = Context.Orders.Count(order => order.Status == Models.Enums.Status.InProgress);
            int completedOrders = Context.Orders.Count(order => order.Status == Models.Enums.Status.Completed);


            CountOrdersVM vm = new CountOrdersVM()
            {
                ActiveOrders = activeOrders,
                InProgressOrders = inProgressOrders,
                CompletedOrders = completedOrders
            };
            return vm;
        }
    }
}
