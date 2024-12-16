using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Core.Models.Data
{
    public class Table : BaseEntity
    {
        [Key]
        public int TableId { get; set; }

        [Required, StringLength(20)]
        public string TableNumber { get; set; }

        [Required]
        public int Capacity { get; set; }

        public bool IsOccupied { get; set; }

        [Required, StringLength(50)]
        public string Status { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
