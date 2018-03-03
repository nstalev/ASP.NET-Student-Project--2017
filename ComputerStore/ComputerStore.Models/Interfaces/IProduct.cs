using ComputerStore.Models.EntityModels.Orders;
using System;
using System.Collections.Generic;

namespace ComputerStore.Models.Interfaces
{
    public interface IProduct
    {
         int Id { get; set; }

         string Brand { get; set; }

         string Model { get; set; }

         Decimal Price { get; set; }

         bool IsAvailable { get; set; }


         ICollection<Order> Orders { get; set; }
         ICollection<CurrentOrder> CurrentOrders { get; set; }
    }
}
