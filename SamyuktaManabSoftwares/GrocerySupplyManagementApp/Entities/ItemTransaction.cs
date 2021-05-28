using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class ItemTransaction
    {
        public string SupplierName { get; set; }
        public long ItemId { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string BillNo { get; set; }
        public decimal? SellPrice { get; set; }
    }
}
