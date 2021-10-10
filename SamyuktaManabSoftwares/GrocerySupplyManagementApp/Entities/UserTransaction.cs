using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class UserTransaction
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string InvoiceNo { get; set; }
        public string BillNo { get; set; }
        public string MemberId { get; set; }
        public long ShareMemberId { get; set; }
        public string SupplierId { get; set; }
        public string DeliveryPersonId { get; set; }
        public string Action { get; set; }
        public string ActionType { get; set; }
        public string Bank { get; set; }
        public string Income { get; set; }
        public string Expense { get; set; }
        public string Narration { get; set; }
        public decimal DueReceivedAmount { get; set; }
        public decimal DuePaymentAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public decimal PaymentAmount { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
