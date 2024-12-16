using RestaurantManagement.Core.Models.Data;
using RestaurantManagement.Repository.MenuItemInventoryRe;

namespace RestaurantManagement.DataAccess
{
    public class MenuItemInventoryRepositry : Repository<MenuItemInventory>, IMenuItemInventoryRepository
    {
        public MenuItemInventoryRepositry(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
