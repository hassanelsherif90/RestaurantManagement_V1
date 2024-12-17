using Microsoft.EntityFrameworkCore.Storage;
using RestaurantManagement.Core.Repository;
using RestaurantManagement.Core.Repository.Categories;
using RestaurantManagement.Core.Repository.Tables;
using RestaurantManagement.Repository.Inventory;
using RestaurantManagement.Repository.MenuItemInventories;
using RestaurantManagement.Repository.MenuItems;
using RestaurantManagement.Repository.OrderItems;
using RestaurantManagement.Repository.Orders;
using RestaurantManagement.Repository.ReservationRe;
using RestaurantManagement.Repository.Suppliers;

namespace RestaurantManagement.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbcontext _context;
        private IDbContextTransaction _transaction;

        public ICategoryRepository Categories { get; private set; }
        public IMenuItemRepository MenuItems { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public ITableRepository Tables { get; private set; }
        public IReservationRepository Reservations { get; private set; }

        public IInventoryRepository Inventory { get; private set; }
        public ISupplierRepository Suppliers { get; private set; }

        public IMenuItemInventoryRepository menuItemInventory { get; private set; }

        public IOrderItemRepository OrderItems { get; private set; }

        public UnitOfWork(ApplicationDbcontext context)
        {
            _context = context;
            Categories = new CategoryRepository(context);
            MenuItems = new MenuItemRepository(context);
            Orders = new OrderRepository(context);
            Tables = new TableRepository(context);
            Reservations = new ReservationRepository(context);
            Inventory = new InventoryRepository(context);
            Suppliers = new SupplierRepository(context);
            menuItemInventory = new MenuItemInventoryRepositry(context);
            OrderItems = new OrderItemRepository(context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                await _transaction.RollbackAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}