using ComputerStore.Models.ViewModels.Addresses;
using System.Collections.Generic;

namespace ComputerStore.Models.BindingModels.Addresses
{
    public class DeleteAddressBm
    {
        public int AddressId { get; set; }

        IEnumerable<AddressVM> AddressVMs { get; set; }
    }
}
