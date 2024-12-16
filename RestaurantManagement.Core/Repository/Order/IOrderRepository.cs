using RestaurantManagement.Core.Models.Data;
using RestaurantManagement.Core.Repository;

namespace RestaurantManagement.Repository.OrderRe
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetOrderWithDetails(int orderId);
        Task<IEnumerable<Order>> GetOrderByUser(int userId);
        Task<IEnumerable<Order>> GetOrderByStatus(string status);
        Task<decimal> GetTotalRevenue(DateTime startDate, DateTime endDate);
    }
}
