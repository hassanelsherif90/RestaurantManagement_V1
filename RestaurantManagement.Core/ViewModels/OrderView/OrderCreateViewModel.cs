using RestaurantManagement.Core.Models.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Core.ViewModels.OrderView
{
    public class OrderCreateViewModel
    {
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required, StringLength(50)]
        public string OrderStatus { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required, StringLength(50)]
        public string PaymentStatus { get; set; }

        [StringLength(50)]
        public string PaymentMethod { get; set; }

        public int TableId { get; set; }
        public Table Tables{ get; set; }

        public ICollection<OrderItem> Items { get; set; }
    }
}
    

