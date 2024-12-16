using RestaurantManagement.ViewModels;

namespace RestaurantManagement.Services.InventorySer
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
