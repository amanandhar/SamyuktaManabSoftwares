namespace GrocerySupplyManagementApp.ViewModels
{
    public class StockAdjustmentView
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public long IncomeExpenseId { get; set; }
        public string Action { get; set; }
        public string Narration { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
