namespace GrocerySupplyManagementApp.Entities
{
    public class User
    {
        public long Id { get; set; }
        public long Counter { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsReadOnly { get; set; }
        public bool Bank { get; set; }
        public bool DailyExpense { get; set; }
        public bool DailySummary { get; set; }
        public bool Employee { get; set; }
        public bool EOD { get; set; }
        public bool ItemPricing { get; set; }
        public bool Member { get; set; }
        public bool POS { get; set; }
        public bool Report { get; set; }
        public bool Setting { get; set; }
        public bool Stock { get; set; }
        public bool Supplier { get; set; }
    }
}
