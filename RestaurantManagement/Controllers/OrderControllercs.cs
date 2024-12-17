using Microsoft.AspNetCore.Mvc;

namespace RestaurantManagement.Controllers;

public class OrderControllercs : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}