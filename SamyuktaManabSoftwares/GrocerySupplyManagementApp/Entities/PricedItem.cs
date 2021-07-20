using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class PricedItem
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public string ItemSubCode { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public long Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ProfitPercent { get; set; }
        public decimal ProfitAmount { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal SalesPricePerUnit { get; set; }
        public DateTime Date { get; set; }
    }
}
