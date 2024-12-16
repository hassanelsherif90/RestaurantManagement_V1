using RestaurantManagement.Core.Models.Data;

namespace RestaurantManagement.Services.MenuItemSer
{
    public interface IMenuItemService
    {
        IEnumerable<MenuItem> GetAllMenuItems();
        MenuItem GetMenuItemById(int id);
        void CreateMenuItem(MenuItem menuItem);
        void UpdateMenuItem(MenuItem menuItem);
        void DeleteMenuItem(int id);
    }
}
