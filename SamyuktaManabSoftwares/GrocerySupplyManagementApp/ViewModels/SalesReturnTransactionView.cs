namespace GrocerySupplyManagementApp.ViewModels
{
    public class SalesReturnTransactionView
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string Description { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal SalesProfit { get; set; }
        public decimal Amount { get; set; }
    }
}
