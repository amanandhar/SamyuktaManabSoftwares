using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
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
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
