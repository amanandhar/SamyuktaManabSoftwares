using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class PurchasedItem
    {
        public string SupplierName { get; set; }
        public string BillNo { get; set; }
        public long ItemId { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal OldPurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
