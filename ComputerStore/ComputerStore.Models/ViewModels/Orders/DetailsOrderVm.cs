using ComputerStore.Models.ViewModels.Addresses;
using System;
using System.Collections.Generic;

namespace ComputerStore.Models.ViewModels.Orders
{
    public class DetailsOrderVm
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public AddressVM DeliveryAddress { get; set; }


        public virtual IEnumerable<BuyProductVm> Products { get; set; }

        public decimal OrderPrice { get; set; }
    }
}
