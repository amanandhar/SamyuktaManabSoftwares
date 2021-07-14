namespace GrocerySupplyManagementApp.DTOs
{
    public class IncomeDetailView
    {
        public long Id { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemBrand { get; set; }
        public int Quantity { get; set; }
        public decimal ProfitAmount { get; set; }
        public decimal Total { get; set; }
    }
}
