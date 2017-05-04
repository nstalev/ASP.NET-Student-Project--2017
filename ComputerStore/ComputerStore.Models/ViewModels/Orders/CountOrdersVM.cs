namespace ComputerStore.Models.ViewModels.Orders
{
    public class CountOrdersVM
    {
        public int ActiveOrders { get; set; }
        public int InProgressOrders { get; set; }
        public int CompletedOrders { get; set; }

    }
}
