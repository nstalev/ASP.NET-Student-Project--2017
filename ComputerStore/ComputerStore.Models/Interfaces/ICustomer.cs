using ComputerStore.Models.EntityModels;
using ComputerStore.Models.EntityModels.Addresses;
using System.Collections.Generic;

namespace ComputerStore.Models.Interfaces
{
    public interface ICustomer
    {

        int Id { get; set; }

        ApplicationUser User { get; set; }

        ICollection<Address> Addresses { get; set; }
    }
}
