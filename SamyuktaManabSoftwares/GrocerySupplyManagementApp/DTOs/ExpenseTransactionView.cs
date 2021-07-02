using System;

namespace GrocerySupplyManagementApp.DTOs
{
    public class ExpenseTransactionView
    {
        public long Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Action { get; set; }
        public string ActionType { get; set; }
        public string Expense { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public decimal Balance { get; set; }
    }
}
