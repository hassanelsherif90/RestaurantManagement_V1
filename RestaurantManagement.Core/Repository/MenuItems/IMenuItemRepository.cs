using RestaurantManagement.Core.Models.Data;
using RestaurantManagement.Core.Repository;

namespace RestaurantManagement.Repository.MenuItems
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        Task<IEnumerable<MenuItem>> GetAvavilableItems();

        Task<MenuItem> GetMenuItemWithDetails(int menuItemId);

        Task<IEnumerable<MenuItem>> GetItemByCategory(int categoryId);
    }
}