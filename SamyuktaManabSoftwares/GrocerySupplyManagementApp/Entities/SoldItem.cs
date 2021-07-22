using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class SoldItem
    {
        public long Id { get; set; }
        public DateTime EndOfDate { get; set; }
        public string MemberId { get; set; }
        public string InvoiceNo { get; set; }
        public long ItemId { get; set; }
        public string ItemSubCode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
