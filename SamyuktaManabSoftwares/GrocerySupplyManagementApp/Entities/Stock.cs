using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class Stock
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public string Type { get; set; }
        public string TypeNo { get; set; }
        public int PurchaseQuantity{ get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PurchaseTotalPrice { get; set; }
        public decimal PurchaseGrandPrice { get; set; }
        public int SalesQuantity { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal SalesTotalPrice { get; set; }
        public decimal SalesGrandPrice { get; set; }
        public decimal StockQuantity { get; set; }
        public decimal StockAmount { get; set; }
        public decimal PerUnitStockAmount { get; set; }
        public DateTime Date { get; set; }
    }
}
