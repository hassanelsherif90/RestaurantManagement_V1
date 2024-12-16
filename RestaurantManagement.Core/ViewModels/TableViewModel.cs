namespace RestaurantManagement.ViewModels
{
    public class TableViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Seats { get; set; }
        public bool IsOccupied { get; set; }
    }
}
