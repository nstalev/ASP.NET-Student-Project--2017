using ComputerStore.Models.EntityModels.Addresses;
using ComputerStore.Models.EntityModels.Products;
using ComputerStore.Models.Enums;
using System;
using System.Collections.Generic;

namespace ComputerStore.Models.EntityModels.Orders
{
    public class Order
    {

        public Order()
        {
            this.Products = new HashSet<Item>();
        }
        public int Id { get; set; }

        public Status Status { get; set; }

        public virtual Customer Buyer { get; set; }


        public DateTime OrderDate { get; set; }

        public virtual OrderAddress Address { get; set; }

        public virtual ICollection<Item> Products { get; set; }

        public decimal OrderPrice { get; set; }

    }
}
