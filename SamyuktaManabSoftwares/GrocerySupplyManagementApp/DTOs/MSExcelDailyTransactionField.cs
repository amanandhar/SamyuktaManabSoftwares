namespace GrocerySupplyManagementApp.DTOs
{
    public class MSExcelDailyTransactionField
    {
        public string Date { get; set; }
        public string Description { get; set; }
        public string MemberSupplierId { get; set; }
        public string InvoiceBillNumber { get; set; }
        public string Type { get; set; }
        public string Bank { get; set; }
        public decimal Amount { get; set; }
    }
}
