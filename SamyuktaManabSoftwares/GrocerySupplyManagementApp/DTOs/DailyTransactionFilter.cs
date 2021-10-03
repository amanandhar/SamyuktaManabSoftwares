namespace GrocerySupplyManagementApp.DTOs
{
    public class DailyTransactionFilter
    {
        public string Date { get; set; }
        public bool IsAll { get; set; }
        public string Service { get; set; }
        public string Purchase { get; set; }
        public string Sales { get; set; }
        public string Payment { get; set; }
        public string Receipt { get; set; }
        public string Expense { get; set; }
        public string BankTransfer { get; set; }
        public string ItemCode { get; set; }
        public string Username { get; set; }
        public string InvoiceNo { get; set; }
    }
}
