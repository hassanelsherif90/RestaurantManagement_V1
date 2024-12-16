using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Core.Models.Data
{
    public class Order : BaseEntity
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required, StringLength(50)]
        public string OrderStatus { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Tax { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required, StringLength(50)]
        public string PaymentStatus { get; set; }

        [StringLength(50)]
        public string PaymentMethod { get; set; }


        public int? TableId { get; set; }
        public virtual Table Table { get; set; }




        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
