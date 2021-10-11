using System;

namespace GrocerySupplyManagementApp.ViewModels
{
    public class ExpenseTransactionView
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string Action { get; set; }
        public string ActionType { get; set; }
        public string Expense { get; set; }
        public string Narration { get; set; }
        public decimal DuePaymentAmount { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal Amount { get; set; }
    }
}
