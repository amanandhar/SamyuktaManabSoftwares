namespace GrocerySupplyManagementApp.DTOs
{
    public class TransactionFilter
    {
        public string Date { get; set; }
        public bool isAll { get; set; }
        public string Purchase { get; set; }
        public string Sales { get; set; }
        public string Payment { get; set; }
        public string Receipt { get; set; }
        public string Expense { get; set; }
        public string ItemCode { get; set; }
        public string User { get; set; }
        public string InvoiceNo { get; set; }
    }
}
