namespace GrocerySupplyManagementApp.ViewModels
{
    public class InvoiceReportView
    {
        public string MemberId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long ContactNo { get; set; }
        public string InvoiceNo { get; set; }
        public string ActionType { get; set; }
        public string EndOfDay { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Vat { get; set; }
        public decimal DueAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public decimal Balance { get; set; }
        public string ItemName { get; set; }
        public string Brand { get; set; }
        public string Unit { get; set; }
        public long Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
