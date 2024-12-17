using RestaurantManagement.Core.Repository;

namespace RestaurantManagement.Services.Services.Reservations
{
    public class ReservationsService : IReservationsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReservationsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int PendingReservations()
        {
            return _unitOfWork.Reservations.CountAsync(r => !r.IsDeleted && r.ReservationDate > DateTime.UtcNow).Result;
        }
    }
}
