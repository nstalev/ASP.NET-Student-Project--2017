using ComputerStore.Models.ViewModels.Addresses;
using ComputerStore.Models.ViewModels.User;
using System;
using System.Collections.Generic;

namespace ComputerStore.Models.ViewModels.Orders
{
    public class DetailsStoreOrderVm
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public string Status { get; set; }
        public AddressVM DeliveryAddress { get; set; }

        public UserProfileVM Buyer { get; set; }

        public virtual IEnumerable<BuyProductVm> Products { get; set; }

        public decimal OrderPrice { get; set; }
    }
}
