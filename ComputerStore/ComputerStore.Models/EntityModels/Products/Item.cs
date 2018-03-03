using ComputerStore.Models.EntityModels.Orders;
using ComputerStore.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace ComputerStore.Models.EntityModels.Products
{
    public class Item : IProduct
    {
        public Item()
        {
            this.Orders = new HashSet<Order>();
        }
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public Decimal Price { get; set; }

        public bool IsAvailable { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<CurrentOrder> CurrentOrders { get; set; }



    }
}
