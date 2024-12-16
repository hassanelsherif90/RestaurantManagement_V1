using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Core.Models.Data
{
    public class InventoryItem : BaseEntity
    {
        [Key]
        public int InventoryItemId { get; set; }


        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(20)]
        public string Unit { get; set; }

        public int CurrentStock { get; set; }
        public int MinimumStock { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitCost { get; set; }

        public DateTime LastRestockDate { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<MenuItemInventory> MenuItems { get; set; }
    }
}
