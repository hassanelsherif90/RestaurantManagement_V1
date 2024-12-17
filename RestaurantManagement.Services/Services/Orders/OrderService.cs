using RestaurantManagement.Core;
using RestaurantManagement.Core.Models.Data;
using RestaurantManagement.Core.Repository;
using RestaurantManagement.Core.ViewModels.OrderView;

namespace RestaurantManagement.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<OrderViewModel> GetAllOrders()
        {
            var orders = _unitOfWork.Orders.GetAllAsync().Result;
            var OrderViewModelList = new List<OrderViewModel>();

            foreach (var order in orders)
            {
                var orderview = new OrderViewModel
                {
                    OrderId = order.OrderId,
                    OrderTime = order.OrderDate,
                    TotalAmount = order.TotalAmount,
                    TableNumber = order.Table.TableNumber,
                    Status = order.OrderStatus,
                };

                OrderViewModelList.Add(orderview);
            }
            return OrderViewModelList;
        }

        public OrderViewModel GetOrderById(int id)
        {
            var order = _unitOfWork.Orders.GetByIdAsync(id).Result;
            var orderview = new OrderViewModel
            {
                OrderId = order.OrderId,
                OrderTime = order.OrderDate,
                TotalAmount = order.TotalAmount,
                TableNumber = order.Table.TableNumber,
                Status = order.OrderStatus,
            };

            return orderview;
        }

        public async void CreateOrder(OrderCreateViewModel model)
        {
            
            //check table 
            var table = await _unitOfWork.Tables.GetByIdAsync(model.TableId);

            if (table == null || table.IsOccupied)
            {
                throw new Exception("الطاولة غير متوفرة ");
            }

            //check items in inentory
            //foreach (var item in model.OrderItems)
            //{
            //    var isAvailable = await _unitOfWork.Inventory.CheckStockAvailability(item.MenuItemId, item.Quantity);
            //    if (!isAvailable)
            //        throw new Exception($"العنصر غير متوفر بالكمية المطلوبة: {item.MenuItemId}");
            //}

            var order = new Order
            {
                TableId = model.TableId,
                OrderDate = DateTime.UtcNow,
                OrderStatus = "Active",
                PaymentStatus = "Pending",
            };

            decimal subtotal = 0;
            var orderItems = new List<OrderItem>();
            foreach (var item in model.Items)
            {
                var menuItem = await _unitOfWork.MenuItems.GetByIdAsync(item.MenuItemId);
                var orderItem = new OrderItem
                {
                    MenuItemId = item.MenuItemId,
                    Quantity = item.Quantity,
                    UnitPrice = menuItem.Price,
                    TotalPrice = menuItem.Price * item.Quantity,
                    SpecialInstructions = item.SpecialInstructions
                };

                orderItems.Add(orderItem);
                subtotal += orderItem.TotalPrice;
            }

            order.SubTotal = subtotal;
            order.Tax = subtotal * 0.15m;
            order.Discount = await CalculateDiscount(1, subtotal);
            order.TotalAmount = order.SubTotal + order.Tax - order.Discount;

            await _unitOfWork.Orders.AddAsync(order);

            foreach (var item in orderItems)
            {
                item.OrderId = order.OrderId;
                await _unitOfWork.OrderItems.AddAsync(item);
            }

            table.IsOccupied = true;
            table.Status = "Occupied";
            _unitOfWork.Tables.UpdateAsync(table);
        }

        public void UpdateOrder(OrderEditViewModel model)
        {
            var order = _unitOfWork.Orders.GetByIdAsync(model.OrderId).Result;
            order.TotalAmount = model.TotalAmount;
            _unitOfWork.Orders.UpdateAsync(order);
            _unitOfWork.CompleteAsync().Wait();
        }

        public void DeleteOrder(int id)
        {
            var order = _unitOfWork.Orders.GetByIdAsync(id).Result;
            _unitOfWork.Orders.RemoveAsync(order);
            _unitOfWork.CompleteAsync().Wait();
        }

        private async Task<decimal> CalculateDiscount(int userId, decimal subtotal)
        {
            //var user = await _unitOfWork.Users.GetByIdAsync(userId);

            //// حساب الخصم بناءً على نوع العضوية
            //if (user.UserRoles.Any(ur => ur.Role.RoleName == "VIP"))
            //    return subtotal * 0.1m;

            return 0;
        }

        public int DayOrders()
        {
            return _unitOfWork.Orders.CountAsync(o => o.OrderDate.Date == DateTime.UtcNow.Date).Result;
        }

        public async Task<IEnumerable<OrderViewModel>> GetRecentOrders()
        {
            var orders = await _unitOfWork.Orders.GetOrderByStatus(enOrderStatus.Confirmed.ToString());

            /*//var orderViewModels = new List<OrderViewModel>();
            //foreach (var order in orders)
            //{
            //    var orderModel = new OrderViewModel
            //    {
            //        OrderId = order.OrderId,
            //        OrderTime = order.OrderDate,
            //        TotalAmount = order.TotalAmount,
            //        Status = order.OrderStatus,
            //        StatusColor = GetStatusColor(order.OrderStatus),
            //        TableNumber = order.Table.TableNumber,

            //    };
            //    orderViewModels.Add(orderModel);

            //}*/

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

        public async Task<decimal> GetTotalRevenue()
        {
            return await _unitOfWork.Orders.GetTotalRevenue(DateTime.UtcNow.Date, DateTime.UtcNow.Date.AddDays(1));
        }
    }
}