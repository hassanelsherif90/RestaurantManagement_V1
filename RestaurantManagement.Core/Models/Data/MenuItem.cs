using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Core.Models.Data
{
    public class MenuItem : BaseEntity
    {
        [Key]
        public int MenuItemId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        [StringLength(255)]
        public string ImageUrl { get; set; }

        // Navigation Properties
        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public ICollection<MenuItemInventory> RequiredInventoryItems { get; set; }
    }
}