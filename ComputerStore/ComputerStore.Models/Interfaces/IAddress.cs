using ComputerStore.Models.EntityModels.Orders;
using System.Collections.Generic;

namespace ComputerStore.Models.Interfaces
{
    public interface IAddress
    {
         int Id { get; set; }

         string City { get; set; }

         string Streat { get; set; }

         string PostCode { get; set; }

         string PhoneNumber { get; set; }

         ICollection<Order> Orders { get; set; }
    }
}
