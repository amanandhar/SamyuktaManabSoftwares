using System;

namespace GrocerySupplyManagementApp.ViewModels
{
    public class ExpenseTransactionView
    {
        public long Id { get; set; }
        public DateTime EndOfDate { get; set; }
        public string Action { get; set; }
        public string ActionType { get; set; }
        public string Expense { get; set; }
        public decimal DueAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public decimal Balance { get; set; }
    }
}
