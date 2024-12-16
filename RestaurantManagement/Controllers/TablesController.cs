using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Services.TableSer;
using RestaurantManagement.ViewModels;

namespace RestaurantManagement.Controllers
{

    public class TablesController : Controller
    {
        private readonly ITableService _tableService;

        public TablesController(ITableService tableService)
        {
            _tableService = tableService;
        }

        public IActionResult Index()
        {
            var tables = _tableService.GetAllTables();
            return View(tables);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(TableViewModel model)
        {
            if (ModelState.IsValid)
            {
                _tableService.CreateTable(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var table = _tableService.GetTableById(id);
            return View(table);
        }

        [HttpPost]
        public IActionResult Edit(TableViewModel model)
        {
            if (ModelState.IsValid)
            {
                _tableService.UpdateTable(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var table = _tableService.GetTableById(id);
            return View(table);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _tableService.DeleteTable(id);
            return RedirectToAction("Index");
        }
    }

}
