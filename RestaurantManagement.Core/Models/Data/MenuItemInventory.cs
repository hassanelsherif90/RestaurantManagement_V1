using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Core.Models.Data
{
    public class MenuItemInventory : BaseEntity
    {
        [Key]
        public int MenuItemInventoryId { get; set; }
        public decimal Quantity { get; set; }

        // Navigation Properties
        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }


        public int InventoryItemId { get; set; }
        public virtual InventoryItem InventoryItem { get; set; }
    }
}
