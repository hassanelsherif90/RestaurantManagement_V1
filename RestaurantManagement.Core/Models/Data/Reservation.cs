using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Core.Models.Data
{
    public class Reservation : BaseEntity
    {
        [Key]
        public int ReservationId { get; set; }

        [Required, StringLength(100)]
        public string CustomerName { get; set; }

        [Required, StringLength(20)]
        public string PhoneNumber { get; set; }

        [EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        public int GuestCount { get; set; }

        [Required, StringLength(50)]
        public string Status { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }



        public int TableId { get; set; }
        public virtual Table Table { get; set; }
    }
}
