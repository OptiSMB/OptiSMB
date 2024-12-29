namespace BusinessSoftware.Client.Models
{
    public class BusinessDashboardModel
    {
        public List<string> PredictiveItems { get; set; } = new List<string>();
        public List<RecentSale> RecentSales { get; set; } = new List<RecentSale>();
        public List<DailySale> DailySales { get; set; } = new List<DailySale>();
    }
}
