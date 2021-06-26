using System;

namespace GrocerySupplyManagementApp.DTOs
{
    public class MemberTransactionView
    {
        public long Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string PaymentType { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public decimal Balance { get; set; }
    }
}
