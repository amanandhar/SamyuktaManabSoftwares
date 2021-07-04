using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class TransactionGrid
    {
        public long Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string MemberSupplierId { get; set; }
        public string Action { get; set; }
        public string ActionType { get; set; }
        public string InvoiceBillNo { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal Amount { get; set; }
    }
}
