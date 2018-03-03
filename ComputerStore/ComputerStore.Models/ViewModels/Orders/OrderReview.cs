using ComputerStore.Models.ViewModels.Addresses;
using System.Collections.Generic;

namespace ComputerStore.Models.ViewModels.Orders
{
    public class OrderReview
    {
        public IEnumerable<BuyProductVm> BuyProductVms { get; set; }

        public AddressVM DeliveryAddress { get; set; }

        public decimal OrderPrice { get; set; }

    }
}
