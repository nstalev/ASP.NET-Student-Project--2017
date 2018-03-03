using ComputerStore.Models.EntityModels;
using ComputerStore.Models.EntityModels.Products;
using System.Collections.Generic;

namespace ComputerStore.Models.Interfaces
{
    public interface IOrder
    {
        int Id { get; set; }

        Customer Buyer { get; set; }

        ICollection<Item> Products { get; set; }

        decimal OrderPrice { get; set; }
    }
}
