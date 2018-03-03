using System;

namespace ComputerStore.Models.ViewModels.Orders
{
    public class DeleteItemVm
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }
        public Decimal Price { get; set; }
    }
}
