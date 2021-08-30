using System;

namespace GrocerySupplyManagementApp.DTOs
{
    public class Stock
    {
        public string EndOfDay { get; set; }
        public string Description { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemUnit { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public decimal SalesQuantity { get; set; }
        public decimal StockQuantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal TotalPurchasePrice { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
