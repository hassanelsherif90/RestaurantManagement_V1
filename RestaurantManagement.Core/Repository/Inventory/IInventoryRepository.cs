using RestaurantManagement.Core.Models.Data;
using RestaurantManagement.Core.Repository;

namespace RestaurantManagement.Repository.Inventory
{
    public interface IInventoryRepository : IRepository<InventoryItem>
    {
    }
}