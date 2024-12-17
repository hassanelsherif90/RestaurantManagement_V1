namespace RestaurantManagement.Core.ViewModels
{
    public class SalesChartData
    {
        public List<string> Labels { get; set; } // التسميات على المحور السيني
        public List<decimal> Values { get; set; } // القيم على المحور الصادي

        public SalesChartData()
        {
            Labels = new List<string>();
            Values = new List<decimal>();
        }
    }
}