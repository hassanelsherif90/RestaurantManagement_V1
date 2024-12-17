namespace RestaurantManagement.Core.ViewModels.OrderView
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string TableNumber { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string StatusColor { get; set; } // لتمييز الحالة بلون مختلف
    }
}