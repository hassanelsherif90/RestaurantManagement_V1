using RestaurantManagement.Core.ViewModels.OrderView;

namespace RestaurantManagement.Core.ViewModels
{
    public class DashboardViewModel
    {
        // عدد الطلبات اليوم
        public int TodayOrders { get; set; }

        // الإيرادات اليوم
        public decimal TodayRevenue { get; set; }

        // عدد الحجوزات المعلقة
        public int PendingReservations { get; set; }

        // عدد المواد المنخفضة
        public int LowStockItems { get; set; }

        // قائمة الطلبات الأخيرة
        public IEnumerable<OrderViewModel> RecentOrders { get; set; }

        // قائمة حالة الطاولات
        public IEnumerable<TableViewModel> Tables { get; set; }

        // بيانات المخطط
        public SalesChartData SalesChartData { get; set; }

        public DashboardViewModel()
        {
            RecentOrders = new List<OrderViewModel>();
            Tables = new List<TableViewModel>();
            SalesChartData = new SalesChartData();
        }
    }
}