using RestaurantManagement.ViewModels.OrderView;

namespace RestaurantManagement.Services.OrderSer
{
    public interface IOrderService
    {
        IEnumerable<OrderViewModel> GetAllOrders();
        OrderViewModel GetOrderById(int id);
        void CreateOrder(OrderCreateViewModel model);
        void UpdateOrder(OrderEditViewModel model);
        void DeleteOrder(int id);

    }
}
