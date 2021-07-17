using System;

namespace GrocerySupplyManagementApp.ViewModels
{
    public class ItemTransactionView
    {
        public string SupplierName { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string BillNo { get; set; }
        public decimal? SellPrice { get; set; }
    }
}
