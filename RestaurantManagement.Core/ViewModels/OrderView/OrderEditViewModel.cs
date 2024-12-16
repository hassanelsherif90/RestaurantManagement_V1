using RestaurantManagement.Models.ViewModels;

namespace RestaurantManagement.ViewModels.OrderView
{
    public class OrderEditViewModel
    {
        public int OrderId { get; set; } // معرف الطلب
        public int TableId { get; set; } // معرف الطاولة
        public decimal TotalAmount { get; set; } // المبلغ الإجمالي
        public IEnumerable<OrderItemViewModel> TableOptions { get; set; } // خيارات الطاولة

    }
}
