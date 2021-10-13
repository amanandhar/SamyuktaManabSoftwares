namespace GrocerySupplyManagementApp.ViewModels
{
    public class DailyTransactionView
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string MemberSupplierId { get; set; }
        public string Action { get; set; }
        public string ActionType { get; set; }
        public string Bank { get; set; }
        public string InvoiceBillNo { get; set; }
        public string Income { get; set; }
        public string Expense { get; set; }
        public decimal Amount { get; set; }
    }
}
