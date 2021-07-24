using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class PurchasedItem
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string SupplierId { get; set; }
        public string BillNo { get; set; }
        public long ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
