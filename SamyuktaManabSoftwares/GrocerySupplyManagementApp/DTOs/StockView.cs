namespace GrocerySupplyManagementApp.DTOs
{
    public class StockView
    {
        public string SupplierName { get; set; }
        public string Date { get; set; }
        public string BillInvoiceNo { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public decimal? SellPrice { get; set; }
    }
}
