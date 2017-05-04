using ComputerStore.Models.EntityModels.Products;
using System.Collections.Generic;

namespace ComputerStore.Models.EntityModels.Orders
{
    public class CurrentOrder
    {
        public CurrentOrder()
        {
            this.Products = new HashSet<Item>();
        }
        public int Id { get; set; }

        public Customer Buyer { get; set; }

        public virtual ICollection<Item> Products { get; set; }

        public decimal OrderPrice { get; set; }
    }
}
