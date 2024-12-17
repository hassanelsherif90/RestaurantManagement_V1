namespace RestaurantManagement.Core.ViewModels
{
    public class InventoryItemViewModel
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int CurrentStock { get; set; }
        public decimal Price { get; set; }
    }
}