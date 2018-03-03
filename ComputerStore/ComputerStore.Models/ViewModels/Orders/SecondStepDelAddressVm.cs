using ComputerStore.Models.ViewModels.Addresses;
using System.Collections.Generic;

namespace ComputerStore.Models.ViewModels.Orders
{
    public class SecondStepDelAddressVm
    {
        public IEnumerable<AddressVM> AddressesVm { get; set; }
    }
}
