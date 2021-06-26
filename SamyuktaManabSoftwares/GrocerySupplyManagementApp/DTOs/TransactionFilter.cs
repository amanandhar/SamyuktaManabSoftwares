namespace GrocerySupplyManagementApp.DTOs
{
    public class TransactionFilter
    {
        public string Date { get; set; }
        public string Sale { get; set; }
        public string PaymentIn { get; set; }
        public string PaymentOut { get; set; }
        public string ItemCode { get; set; }
        public string User { get; set; }
        public string InvoiceNo { get; set; }
    }
}
