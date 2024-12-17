using RestaurantManagement.Core.ViewModels.OrderView;

namespace RestaurantManagement.Services.Order

{
    public interface IOrderService
    {
        IEnumerable<OrderViewModel> GetAllOrders();

        OrderViewModel GetOrderById(int id);

        //void CreateOrder(OrderCreateViewModel model);

        void UpdateOrder(OrderEditViewModel model);

        void DeleteOrder(int id);

        int DayOrders();
        Task<IEnumerable<OrderViewModel>> GetRecentOrders();
        Task<decimal> GetTotalRevenue();
    }
}