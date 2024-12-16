using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.ViewModels.OrderView
{
    public class MenuItemViewModel
    {
        public int MenuItemId { get; set; }

        [Required]
        [Display(Name = "اسم العنصر")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "السعر")]
        [Range(0, double.MaxValue, ErrorMessage = "السعر يجب أن يكون أكبر من 0")]
        public decimal Price { get; set; }
    }
}
