using System;

namespace GrocerySupplyManagementApp.ViewModels
{
    public class TransactionView
    {
        public long Id { get; set; }
        public DateTime EndOfDate { get; set; }
        public string MemberSupplierId { get; set; }
        public string Action { get; set; }
        public string ActionType { get; set; }
        public string InvoiceBillNo { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal Amount { get; set; }
    }
}
