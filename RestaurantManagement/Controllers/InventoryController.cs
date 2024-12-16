using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Services.InventorySer;
using RestaurantManagement.ViewModels;

namespace RestaurantManagement.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public IActionResult Index()
        {
            var items = _inventoryService.GetAllItems();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(InventoryItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                _inventoryService.CreateItem(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var item = _inventoryService.GetItemById(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(InventoryItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                _inventoryService.UpdateItem(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var item = _inventoryService.GetItemById(id);
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _inventoryService.DeleteItem(id);
            return RedirectToAction("Index");
        }
    }
}
