using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Core.ViewModels;
using RestaurantManagement.Services.Tables;

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
            var tableOptions = _tableService.GetTableOptions();
            return View("Index", tableOptions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(TableViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _tableService.CreateTable(model);
                    return RedirectToAction("Index", "Dashboard");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                }
            }

            return View("Create", model);
        }
    }
}