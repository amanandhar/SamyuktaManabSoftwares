using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class TransactionGrid
    {
        public DateTime InvoiceDate { get; set; }
        public string MemberId { get; set; }
        public string Descriptions { get; set; }
        public string InvoiceNo { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemBrand { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal Amount { get; set; }
    }
}
