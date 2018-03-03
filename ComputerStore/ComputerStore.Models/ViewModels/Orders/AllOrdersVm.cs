using System;

namespace ComputerStore.Models.ViewModels.Orders
{
    public class AllOrdersVm
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal OrderPrice { get; set; }

        public string Status { get; set; }

    }
}
