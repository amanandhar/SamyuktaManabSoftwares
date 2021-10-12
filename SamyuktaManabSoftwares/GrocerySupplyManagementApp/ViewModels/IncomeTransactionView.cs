using System;

namespace GrocerySupplyManagementApp.ViewModels
{
    public class IncomeTransactionView
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string InvoiceNo { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemBrand { get; set; }
        public decimal Quantity { get; set; }
        public decimal Profit { get; set; }
        public decimal Amount { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
