using System;

namespace GrocerySupplyManagementApp.ViewModels
{
    public class IncomeTransactionView
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string Description { get; set; }
        public string Narration { get; set; }
        public string InvoiceNo { get; set; }
        public string BankName { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal Amount { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
