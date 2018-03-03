using ComputerStore.Models.EntityModels.Orders;
using ComputerStore.Models.Interfaces;
using System.Collections.Generic;

namespace ComputerStore.Models.EntityModels.Addresses
{
    public class OrderAddress : IAddress
    {
        public OrderAddress()
        {
            this.Orders = new HashSet<Order>();
        }
        public int Id { get; set; }

        public string City { get; set; }

        public string Streat { get; set; }

        public string PostCode { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
