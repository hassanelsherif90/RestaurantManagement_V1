using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Core.Repository;
using RestaurantManagement.ViewModels;
using RestaurantManagement.ViewModels.OrderView;


public class DashboardController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public DashboardController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var model = new DashboardViewModel
        {
            TodayOrders = await _unitOfWork.Orders.CountAsync(o => o.OrderDate.Date == DateTime.UtcNow.Date),
            TodayRevenue = await _unitOfWork.Orders.GetTotalRevenue(DateTime.UtcNow.Date, DateTime.UtcNow),
            PendingReservations = await _unitOfWork.Reservations.CountAsync(r => !r.IsDeleted && r.ReservationDate > DateTime.UtcNow),
            LowStockItems = await _unitOfWork.Inventory.CountAsync(i => i.CurrentStock < 5),
            RecentOrders = await GetRecentOrders(),
            Tables = await GetTables(),
            SalesChartData = await GetSalesChartData()
        };

        return View(model);
    }

    private async Task<IEnumerable<OrderViewModel>> GetRecentOrders()
    {
        var orders = await _unitOfWork.Orders.GetOrderByStatus("Completed");
        var orderViewModels = orders.Select(o => new OrderViewModel
        {
            OrderId = o.OrderId,
            TableNumber = o.Table.TableNumber,
            OrderTime = o.OrderDate,
            TotalAmount = o.TotalAmount,
            Status = o.OrderStatus,
            StatusColor = GetStatusColor(o.OrderStatus)
        }).Take(5).ToList();

        return orderViewModels;
    }

    private async Task<IEnumerable<TableViewModel>> GetTables()
    {
        var tables = await _unitOfWork.Tables.GetAllAsync();
        return tables.Select(t => new TableViewModel
        {
            Number = t.TableNumber,
            IsOccupied = t.IsOccupied == false
        }).ToList();
    }

    private async Task<SalesChartData> GetSalesChartData()
    {
        var data = new SalesChartData();
        return data;
    }

    private string GetStatusColor(string status)
    {
        return status switch
        {
            "Pending" => "warning",
            "Completed" => "success",
            "Cancelled" => "danger",
            _ => "secondary"
        };
    }
}
