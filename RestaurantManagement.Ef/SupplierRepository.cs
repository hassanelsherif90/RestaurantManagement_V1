using RestaurantManagement.Core.Models.Data;
using RestaurantManagement.Repository.Suppliers;

namespace RestaurantManagement.DataAccess
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}