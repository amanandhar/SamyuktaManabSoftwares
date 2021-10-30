using System;

namespace GrocerySupplyManagementApp.ViewModels
{
    public class ExpenseTransactionView
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string Description { get; set; }
        public string Narration { get; set; }
        public string ActionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
