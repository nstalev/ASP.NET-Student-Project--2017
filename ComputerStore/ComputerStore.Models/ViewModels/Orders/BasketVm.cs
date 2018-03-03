using System.Collections.Generic;

namespace ComputerStore.Models.ViewModels.Orders
{
    public class BasketVm
    {
        public IEnumerable<BuyProductVm> BuyProductVms { get; set; }

        public decimal OrderPrice { get; set; }

    }
}
