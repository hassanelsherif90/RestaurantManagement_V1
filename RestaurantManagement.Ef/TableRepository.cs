
using RestaurantManagement.Core.Models.Data;
using RestaurantManagement.Core.Repository.TableRe;

namespace RestaurantManagement.DataAccess
{
    public class TableRepository : Repository<Table>, ITableRepository
    {
        public TableRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }


    }
}
