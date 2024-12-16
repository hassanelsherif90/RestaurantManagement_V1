/*using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models.Data;
using RestaurantManagement.Services;

namespace RestaurantManagement.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuItemService _menuItemService;

        public MenuController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        public IActionResult Index()
        {
            IEnumerable<MenuItem> menuItems = _menuItemService.GetAllMenuItems();
            return View(menuItems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MenuItem model)
        {
            if (ModelState.IsValid)
            {
                _menuItemService.CreateMenuItem(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            MenuItem menuItem = _menuItemService.GetMenuItemById(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return View(menuItem);
        }

        [HttpPost]
        public IActionResult Edit(MenuItem model)
        {
            if (ModelState.IsValid)
            {
                _menuItemService.UpdateMenuItem(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            MenuItem menuItem = _menuItemService.GetMenuItemById(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return View(menuItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _menuItemService.DeleteMenuItem(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            MenuItem menuItem = _menuItemService.GetMenuItemById(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return View(menuItem);
        }
    }
}*/
