namespace GrocerySupplyManagementApp.DTOs
{
    public class DailyTransactionFilter
    {
        public string Date { get; set; }
        public bool IsAll { get; set; }
        public string Purchase { get; set; }
        public string Sales { get; set; }
        public string Payment { get; set; }
        public string Receipt { get; set; }
        public string Username { get; set; }
        public string PartyNumber { get; set; }
    }
}
