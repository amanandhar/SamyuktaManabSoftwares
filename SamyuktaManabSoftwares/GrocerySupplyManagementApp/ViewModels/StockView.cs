using System;

namespace GrocerySupplyManagementApp.ViewModels
{
    public class StockView
    {
        public string EndOfDay { get; set; }
        public string Description { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int PurchaseQuantity { get; set; }
        public int SalesQuantity { get; set; }
        public int StockQuantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal TotalPurchasePrice { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal StockValue { get; set; }
        public decimal PerUnitValue { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
