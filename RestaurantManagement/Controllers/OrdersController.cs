
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Core.Repository;
using RestaurantManagement.Models.ViewModels;
using RestaurantManagement.Services.OrderSer;
using RestaurantManagement.Services.TableSer;
using RestaurantManagement.ViewModels;
using RestaurantManagement.ViewModels.OrderView;

namespace RestaurantManagement.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ITableService _tableService;
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IOrderService orderService, ITableService tableService, IUnitOfWork unitOfWork)
        {
            _orderService = orderService;
            _tableService = tableService;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }

        public IActionResult Create()
        {

            var tables = _unitOfWork.Tables.GetAllAsync().Result;
            List<TableViewModel>? TableViewList = new List<TableViewModel>();

            foreach (var table in tables)
            {
                var TableView = new TableViewModel
                {
                    Id = table.TableId,
                    IsOccupied = table.IsOccupied,
                    Number = table.TableNumber,
                    Seats = table.Capacity
                };

                TableViewList.Add(TableView);
            }


            var model = new OrderCreateViewModel
            {
                TableOptions = TableViewList.Select(tableViewModel => new OrderItemViewModel
                {
                    MenuItemId = tableViewModel.Id,
                    Quantity = tableViewModel.Seats
                }).ToList()


            };
            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Create(OrderCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _orderService.CreateOrder(model);
                return RedirectToAction("Index");
            }

            model.TableOptions = _tableService.GetTableOptions().Select(t => new OrderItemViewModel
            {

                MenuItemId = t.Id,
                Quantity = t.Seats
            }).ToList();
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            OrderViewModel? order = _orderService.GetOrderById(id);




            var model = new OrderEditViewModel
            {
                OrderId = order.OrderId,
                //TableId = order.TableNumber,
                TotalAmount = order.TotalAmount,
                TableOptions = _tableService.GetTableOptions().Select(t => new OrderItemViewModel
                {
                    MenuItemId = t.Id,
                    Quantity = t.Seats


                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(OrderEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                _orderService.UpdateOrder(model);
                return RedirectToAction("Index");
            }

            model.TableOptions = _tableService.GetTableOptions().Select(t => new OrderItemViewModel
            {
                MenuItemId = t.Id,
                Quantity = t.Seats

            }).ToList();

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var order = _orderService.GetOrderById(id);
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _orderService.DeleteOrder(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var order = _orderService.GetOrderById(id);
            return View(order);
        }
    }

}
