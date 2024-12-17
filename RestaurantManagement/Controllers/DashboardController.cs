using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Core.Repository;
using RestaurantManagement.Core.ViewModels;
using RestaurantManagement.Services.Order;
using RestaurantManagement.Services.Services.Reservations;
using RestaurantManagement.Services.Tables;

public class DashboardController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderService _orderServices;
    private readonly IReservationsService _reservationsService;

    public ITableService _tableService { get; }

    public DashboardController(IUnitOfWork unitOfWork, IOrderService orderServices, ITableService tableService, IReservationsService reservationsService)
    {
        _unitOfWork = unitOfWork;
        _orderServices = orderServices;
        _tableService = tableService;
        _reservationsService = reservationsService;
    }

    public async Task<IActionResult> Index()
    {
        var model = new DashboardViewModel
        {
            TodayOrders = _orderServices.DayOrders(),
            TodayRevenue = await _orderServices.GetTotalRevenue(),
            PendingReservations = _reservationsService.PendingReservations(),
            LowStockItems = await _unitOfWork.Inventory.CountAsync(i => i.CurrentStock < 5),
            RecentOrders = await _orderServices.GetRecentOrders(),
            Tables = await _tableService.GetTables(),
            SalesChartData = await GetSalesChartData()
        };

        return View(model);
    }




    private async Task<SalesChartData> GetSalesChartData()
    {
        var data = new SalesChartData();
        return data;
    }
}