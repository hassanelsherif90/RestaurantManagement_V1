using RestaurantManagement.Core.Models.Data;
using RestaurantManagement.Repository.Inventory;

namespace RestaurantManagement.DataAccess
{
    public class InventoryRepository : Repository<InventoryItem>, IInventoryRepository
    {
        public InventoryRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}