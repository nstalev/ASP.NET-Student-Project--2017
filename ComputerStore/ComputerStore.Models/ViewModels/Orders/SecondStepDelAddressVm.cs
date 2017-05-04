using ComputerStore.Models.ViewModels.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Models.ViewModels.Orders
{
    public class SecondStepDelAddressVm
    {
        public IEnumerable<AddressVM> AddressesVm { get; set; }
    }
}
