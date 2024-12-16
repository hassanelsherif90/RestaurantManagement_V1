using RestaurantManagement.Models.ViewModels;

namespace RestaurantManagement.ViewModels.OrderView
{
    public class OrderCreateViewModel
    {
        public int TableId { get; set; }
        public IEnumerable<OrderItemViewModel> TableOptions { get; set; }

    }
}
