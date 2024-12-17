using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Core.Models.Data
{
    public class Category : BaseEntity
    {
        [Key]
        public int CategoryId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public ICollection<MenuItem> MenuItems { get; set; }
    }
}