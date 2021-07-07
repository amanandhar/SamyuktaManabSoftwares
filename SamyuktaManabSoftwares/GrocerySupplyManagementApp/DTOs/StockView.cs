namespace GrocerySupplyManagementApp.DTOs
{
    public class StockView
    {
        public string SupplierName { get; set; }
        public string PurchaseDate { get; set; }
        public string BillNo { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Total { get; set; }
        public decimal? SellPrice { get; set; }
    }
}
