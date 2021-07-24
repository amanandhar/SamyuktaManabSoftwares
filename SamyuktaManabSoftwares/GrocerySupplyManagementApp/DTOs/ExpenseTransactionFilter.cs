using System;

namespace GrocerySupplyManagementApp.DTOs
{
    public class ExpenseTransactionFilter
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Expense { get; set; }
    }
}
