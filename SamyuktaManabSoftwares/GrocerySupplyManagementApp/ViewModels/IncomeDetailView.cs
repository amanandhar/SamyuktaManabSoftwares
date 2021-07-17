namespace GrocerySupplyManagementApp.ViewModels
{
    public class IncomeDetailView
    {
        public long Id { get; set; }
        public string EndOfDate { get; set; }
        public string InvoiceNo { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemBrand { get; set; }
        public int Quantity { get; set; }
        public decimal ProfitAmount { get; set; }
        public decimal Total { get; set; }
    }
}
