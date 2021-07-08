namespace GrocerySupplyManagementApp.Entities
{
    public class CodedItem
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public string ItemSubCode { get; set; }
        public string Unit { get; set; }
        public long Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal? CurrentPurchasePrice { get; set; }
        public long Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal ProfitPercent { get; set; }
        public decimal ProfitAmount { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal SalesPricePerUnit { get; set; }
    }
}
