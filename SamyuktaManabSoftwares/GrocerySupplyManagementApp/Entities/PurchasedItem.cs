using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class PurchasedItem
    {
        public long Id { get; set; }
        public DateTime EndOfDate { get; set; }
        public string SupplierId { get; set; }
        public string BillNo { get; set; }
        public long ItemId { get; set; }
        public string Unit { get; set; }
        public long Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
