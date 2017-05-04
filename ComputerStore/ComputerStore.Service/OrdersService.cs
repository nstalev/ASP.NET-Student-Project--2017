using System.Collections.Generic;
using System.Linq;
using ComputerStore.Models.ViewModels.Orders;
using ComputerStore.Models.EntityModels.Products;
using AutoMapper;
using ComputerStore.Models.ViewModels.Addresses;
using ComputerStore.Models.EntityModels;
using ComputerStore.Models.EntityModels.Addresses;
using ComputerStore.Models.EntityModels.Orders;
using System;
using ComputerStore.Models.BindingModels.Orders;

namespace ComputerStore.Service
{
    public class OrdersService : Service
    {

      
        public void AddProductuToCurrentOrder(int id, string userName)
        {

            Item item = Context.Items.Find(id);
            Customer customer = Context.Customers.FirstOrDefault(cust => cust.User.UserName == userName);

            CurrentOrder currentOrder = Context.CurrentOrders.FirstOrDefault(order => order.Buyer.Id == customer.Id);
           
            if (currentOrder == null)
            {
                CurrentOrder newCurrentOrder = new CurrentOrder()
                {
                    Buyer = customer
                };
          
                newCurrentOrder.Products.Add(item);
                newCurrentOrder.OrderPrice += item.Price;

                Context.CurrentOrders.Add(newCurrentOrder);
                Context.SaveChanges();
            }
            else
            {
                currentOrder.Products.Add(item);
                currentOrder.OrderPrice += item.Price;
                Context.SaveChanges();
            }

           
        }



        public BasketVm GetBasketVm(string userName)   
        {
            Customer customer = Context.Customers.FirstOrDefault(cust => cust.User.UserName == userName);
            CurrentOrder currentOrder = Context.CurrentOrders.FirstOrDefault(order => order.Buyer.Id == customer.Id);
           

            if (currentOrder != null)
            {
                IEnumerable<Item> products = currentOrder.Products;

                IEnumerable<BuyProductVm> productVms = Mapper.Map<IEnumerable<Item>, IEnumerable<BuyProductVm>>(products);

                BasketVm vm = new BasketVm()
                {
                    BuyProductVms = productVms,
                    OrderPrice = currentOrder.OrderPrice

                };

                return vm;
            }
            else
            {
                BasketVm vm = new BasketVm();

                return vm;
            }

           

        }


        public DeleteItemVm GetDeleteItemVm(int productId)
        {
            Item item = Context.Items.Find(productId);

            DeleteItemVm vm = Mapper.Map<Item, DeleteItemVm>(item);

            return vm;
        }


        public void DeleteProductFromBasket(DeleteItemrBm bind, string userName)
        {
            Item item = Context.Items.Find(bind.ProductId);
            Customer customer = Context.Customers.FirstOrDefault(cust => cust.User.UserName == userName);
            CurrentOrder currentOrder = Context.CurrentOrders.FirstOrDefault(order => order.Buyer.Id == customer.Id);

            currentOrder.Products.Remove(item);
            currentOrder.OrderPrice -= item.Price;
            Context.SaveChanges();

        }



        public SecondStepDelAddressVm SecondStepDelAddressVm(string userName)
        {
       
            Customer customer = Context.Customers.FirstOrDefault(cust => cust.User.UserName == userName);
       
            IEnumerable<Address> addresses = customer.Addresses;
       
            IEnumerable<AddressVM> AddresesVms = Mapper.Map<IEnumerable<Address>, IEnumerable<AddressVM>>(addresses);

            SecondStepDelAddressVm secondStemVm = new SecondStepDelAddressVm()
            {
                AddressesVm = AddresesVms

            };
            return secondStemVm;
        }



        public OrderReview OrderReviewVm(int id, string userName)
        {
            Customer customer = Context.Customers.FirstOrDefault(cust => cust.User.UserName == userName);
            CurrentOrder currentOrder = Context.CurrentOrders.FirstOrDefault(order => order.Buyer.Id == customer.Id);

            Address delAddress = Context.Addresses.Find(id);
            AddressVM delAddressVm = Mapper.Map<Address, AddressVM>(delAddress);


            IEnumerable<Item> products = currentOrder.Products;
            IEnumerable<BuyProductVm> productVms = Mapper.Map<IEnumerable<Item>, IEnumerable<BuyProductVm>>(products);


            OrderReview vm = new OrderReview()
            {
                 DeliveryAddress = delAddressVm,
                  BuyProductVms  = productVms,
                  OrderPrice = currentOrder.OrderPrice
            };

            return vm;
        }



        public void  CreateOrder(ConfirmOrder bind, string userName)
        {
            Customer customer = Context.Customers.FirstOrDefault(cust => cust.User.UserName == userName);
            CurrentOrder currentOrder = Context.CurrentOrders.FirstOrDefault(order1 => order1.Buyer.Id == customer.Id);

            Address delAddress = Context.Addresses.Find(bind.AddressId);

            OrderAddress orderAddress = new OrderAddress()
            {
                Id = delAddress.Id,
                City = delAddress.City,
                PostCode = delAddress.PostCode,
                PhoneNumber = delAddress.PhoneNumber,
                 Streat = delAddress.Streat
            };

            Context.OrderAddresses.Add(orderAddress);
            Context.SaveChanges();


            IEnumerable<Item> products = currentOrder.Products;

            Order order = new Order()
            {
                Address = orderAddress,
                Buyer = customer,
                Status = Models.Enums.Status.Active,
                OrderDate = DateTime.Now,
                OrderPrice = currentOrder.OrderPrice,
                Products = products.ToList()
                
            };

  //          delAddress.Orders.Add(order);

            Context.Orders.Add(order);
            Context.CurrentOrders.Remove(currentOrder);

            Context.SaveChanges();

        }

        public ConfirmedOrderVm GetOrderId(string userName)
        {
            Customer customer = Context.Customers.FirstOrDefault(cust => cust.User.UserName == userName);

            Order order = Context.Orders.OrderByDescending(order1 =>order1.Id).FirstOrDefault(ord => ord.Buyer.Id == customer.Id);
            int orderId = order.Id;

            ConfirmedOrderVm vm = new ConfirmedOrderVm()
            {
                OrderId = orderId
            };
            return vm;
        }


    }
}
