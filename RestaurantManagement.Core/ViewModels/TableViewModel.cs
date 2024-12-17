namespace RestaurantManagement.Core.ViewModels
{
    public class TableViewModel
    {
        public int Id { get; set; }
        public string TableNumber { get; set; }

        public int Capacity { get; set; }

        public bool IsOccupied { get; set; }

        public string Status { get; set; }
    }
}