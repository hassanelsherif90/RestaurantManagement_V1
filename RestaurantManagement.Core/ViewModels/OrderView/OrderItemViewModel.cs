using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models.ViewModels
{
    public class OrderItemViewModel
    {
        public int OrderItemId { get; set; }

        [Required(ErrorMessage = "الكمية مطلوبة.")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن تكون الكمية أكبر من 0.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "سعر الوحدة مطلوب.")]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        public decimal TotalPrice => Quantity * UnitPrice;

        [StringLength(500, ErrorMessage = "تجاوزت الحد الأقصى لعدد الأحرف.")]
        public string SpecialInstructions { get; set; }

        public int OrderId { get; set; }

        public int MenuItemId { get; set; }
    }
}
