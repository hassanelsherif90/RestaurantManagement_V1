
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Core.Repository;
using RestaurantManagement.DataAccess;
using RestaurantManagement.Services.InventorySer;
using RestaurantManagement.Services.MenuItemSer;
using RestaurantManagement.Services.OrderSer;
using RestaurantManagement.Services.TableSer;

namespace RestaurantManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbcontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));//.UseLazyLoadingProxies();

            });

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IInventoryService, InventoryService>();
            builder.Services.AddScoped<ITableService, TableService>();
            builder.Services.AddScoped<IMenuItemService, MenuItemService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Dashboard}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
