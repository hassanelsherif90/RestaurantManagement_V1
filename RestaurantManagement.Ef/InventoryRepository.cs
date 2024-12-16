using RestaurantManagement.Core.Models.Data;
using RestaurantManagement.Repository.InventoryRe;

namespace RestaurantManagement.DataAccess
{
    public class InventoryRepository : Repository<InventoryItem>, IInventoryRepository
    {
        public InventoryRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
