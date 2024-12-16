using RestaurantManagement.Core.Models.Data;
using RestaurantManagement.Repository.SupplierRe;

namespace RestaurantManagement.DataAccess
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
