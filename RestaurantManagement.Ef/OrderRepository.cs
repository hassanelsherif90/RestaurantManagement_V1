using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Core.Models.Data;
using RestaurantManagement.Repository.OrderRe;


namespace RestaurantManagement.DataAccess
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrderByStatus(string status)
        {
            return await _entities
                .Where(o => o.OrderStatus == status && !o.IsDeleted)
                .Include(o => o.OrderItems)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrderByUser(int userId)
        {
            return await _entities
                 .Where(o => !o.IsDeleted)
                 .Include(o => o.OrderItems)
                 .OrderByDescending(o => o.OrderDate)
                 .ToListAsync();
        }

        public async Task<Order> GetOrderWithDetails(int orderId)
        {
            return await _entities
                 .Include(o => o.OrderItems)
                 .ThenInclude(oi => oi.MenuItem)

                 .Include(o => o.Table)
                 .FirstOrDefaultAsync(o => o.OrderId == orderId && !o.IsDeleted);
        }

        public async Task<decimal> GetTotalRevenue(DateTime startDate, DateTime endDate)
        {
            return await _entities.Where(o => !o.IsDeleted &&
            o.OrderDate >= startDate &&
            o.OrderDate <= endDate &&
            o.OrderStatus == "Paid")
                .SumAsync(o => o.TotalAmount);
        }
    }
}
