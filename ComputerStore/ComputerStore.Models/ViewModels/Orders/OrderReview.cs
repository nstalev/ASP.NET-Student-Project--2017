using ComputerStore.Models.ViewModels.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Models.ViewModels.Orders
{
    public class OrderReview
    {
        public IEnumerable<BuyProductVm> BuyProductVms { get; set; }

        public AddressVM DeliveryAddress { get; set; }

        public decimal OrderPrice { get; set; }

    }
}
