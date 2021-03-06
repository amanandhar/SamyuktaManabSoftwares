namespace GrocerySupplyManagementApp.ViewModels
{
    public class InvoiceReportView
    {
        public string MemberId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long ContactNo { get; set; }
        public string AccountNo { get; set; }
        public string InvoiceNo { get; set; }
        public string ActionType { get; set; }
        public string EndOfDay { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal Discount { get; set; }
        public decimal DeliveryCharge { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DueReceivedAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal CustomizedQuantity { get; set; }
        public decimal Price { get; set; }
        public decimal ItemDiscount { get; set; }
        public decimal Amount { get; set; }
        public int ItemNo { get; set; }
    }
}
