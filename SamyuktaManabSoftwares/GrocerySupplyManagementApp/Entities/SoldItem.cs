using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class SoldItem
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string MemberId { get; set; }
        public string InvoiceNo { get; set; }
        public long ItemId { get; set; }
        public decimal Profit { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
