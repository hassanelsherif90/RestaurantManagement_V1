using RestaurantManagement.Core.Repository.Categories;
using RestaurantManagement.Core.Repository.Tables;
using RestaurantManagement.Repository.Inventory;
using RestaurantManagement.Repository.MenuItemInventories;
using RestaurantManagement.Repository.MenuItems;
using RestaurantManagement.Repository.OrderItems;
using RestaurantManagement.Repository.Orders;
using RestaurantManagement.Repository.ReservationRe;
using RestaurantManagement.Repository.Suppliers;

namespace RestaurantManagement.Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IInventoryRepository Inventory { get; }
        IMenuItemRepository MenuItems { get; }
        IMenuItemInventoryRepository menuItemInventory { get; }
        IOrderRepository Orders { get; }
        IOrderItemRepository OrderItems { get; }
        IReservationRepository Reservations { get; }

        ISupplierRepository Suppliers { get; }
        ITableRepository Tables { get; }

        Task<int> CompleteAsync();

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();
    }
}