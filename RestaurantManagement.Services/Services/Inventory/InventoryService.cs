using RestaurantManagement.Core.Models.Data;
using RestaurantManagement.Core.Repository;
using RestaurantManagement.ViewModels;

namespace RestaurantManagement.Services.InventorySer
{
    public class InventoryService : IInventoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<InventoryItemViewModel> GetAllItems()
        {
            var items = _unitOfWork.Inventory.GetAllAsync().Result;
            var inventoryItemViewModelList = new List<InventoryItemViewModel>();

            foreach (var item in items)
            {
                var itemViewModel = new InventoryItemViewModel
                {
                    Id = item.InventoryItemId,
                    CurrentStock = item.CurrentStock,
                    ItemName = item.Name,
                    Price = item.UnitCost,
                };

                inventoryItemViewModelList.Add(itemViewModel);

            }


            return inventoryItemViewModelList;
        }

        public InventoryItemViewModel GetItemById(int id)
        {
            var item = _unitOfWork.Inventory.GetByIdAsync(id).Result;
            var itemViewModel = new InventoryItemViewModel
            {
                Id = item.InventoryItemId,
                CurrentStock = item.CurrentStock,
                ItemName = item.Name,
                Price = item.UnitCost,
            };
            return itemViewModel;
        }

        public void CreateItem(InventoryItemViewModel model)
        {
            var item = new InventoryItem
            {
                InventoryItemId = model.Id,
                CurrentStock = model.CurrentStock,
                Name = model.ItemName,
                UnitCost = model.Price,


            };
            _unitOfWork.Inventory.AddAsync(item).Wait();
            _unitOfWork.CompleteAsync().Wait();
        }

        public void UpdateItem(InventoryItemViewModel model)
        {
            var item = _unitOfWork.Inventory.GetByIdAsync(model.Id).Result;
            // تحديث الخصائص حسب الحاجة
            item.Name = model.ItemName;
            item.CurrentStock = model.CurrentStock;
            _unitOfWork.Inventory.UpdateAsync(item);
            _unitOfWork.CompleteAsync().Wait();
        }

        public void DeleteItem(int id)
        {
            var item = _unitOfWork.Inventory.GetByIdAsync(id).Result;
            _unitOfWork.Inventory.RemoveAsync(item);
            _unitOfWork.CompleteAsync().Wait();
        }
    }
}
