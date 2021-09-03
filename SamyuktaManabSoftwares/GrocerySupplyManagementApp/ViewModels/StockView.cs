using System;

namespace GrocerySupplyManagementApp.ViewModels
{
    public class StockView
    {
        public string EndOfDay { get; set; }
        public string Description { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public decimal SalesQuantity { get; set; }
        public string Unit { get; set; }
        public decimal StockQuantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal TotalPurchasePrice { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal StockValue { get; set; }
        public decimal PerUnitValue { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
