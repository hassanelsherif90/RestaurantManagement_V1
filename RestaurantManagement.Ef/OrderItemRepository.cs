using RestaurantManagement.Core.Models.Data;
using RestaurantManagement.Repository.OrderItemRepo;

namespace RestaurantManagement.DataAccess
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
