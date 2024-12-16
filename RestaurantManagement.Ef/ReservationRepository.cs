using RestaurantManagement.Core.Models.Data;
using RestaurantManagement.Repository.ReservationRe;

namespace RestaurantManagement.DataAccess
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
