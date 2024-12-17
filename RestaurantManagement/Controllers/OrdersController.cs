using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Services.Orders;

namespace RestaurantManagement.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;
        public OrdersController(IOrderService order)
        {
            orderService = order;   
        }
        public IActionResult Index()
        {
            var orders = orderService.GetAllOrders();

            return View(orders);
        }


        [HttpGet]
        public IActionResult Create()
        {

            return View("Create");
        }
    }
}
