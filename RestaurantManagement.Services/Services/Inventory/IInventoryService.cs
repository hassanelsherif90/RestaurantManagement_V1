using RestaurantManagement.Core.ViewModels;

namespace RestaurantManagement.Services.Inventory
{
    public interface IInventoryService
    {
        IEnumerable<InventoryItemViewModel> GetAllItems();

        InventoryItemViewModel GetItemById(int id);

        void CreateItem(InventoryItemViewModel model);

        void UpdateItem(InventoryItemViewModel model);

        void DeleteItem(int id);
    }
}