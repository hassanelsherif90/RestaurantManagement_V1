using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Core.Models.Data;



namespace RestaurantManagement.DataAccess
{
    public class ApplicationDbcontext : DbContext
    {

        public DbSet<Category> categories { get; set; }
        public DbSet<InventoryItem> inventoryItems { get; set; }
        public DbSet<MenuItem> menuItems { get; set; }
        public DbSet<MenuItemInventory> menuItemInventories { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Reservation> reservations { get; set; }

        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<Table> table { get; set; }

        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {

        }


    }
}
