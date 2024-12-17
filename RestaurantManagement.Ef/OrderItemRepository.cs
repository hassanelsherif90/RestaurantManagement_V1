using RestaurantManagement.Core.Models.Data;
using RestaurantManagement.Repository.OrderItems;

namespace RestaurantManagement.DataAccess
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}