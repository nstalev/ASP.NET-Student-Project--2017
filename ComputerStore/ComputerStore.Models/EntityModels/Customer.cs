using ComputerStore.Models.EntityModels.Addresses;
using ComputerStore.Models.EntityModels.Orders;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStore.Models.EntityModels
{
    public class Customer
    {

        public Customer()
        {
            this.Addresses = new HashSet<Address>();
            this.OrdersBuyer = new HashSet<Order>();

        }
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        [InverseProperty("Buyer")]
        public virtual ICollection<Order> OrdersBuyer { get; set; }


    }
}
