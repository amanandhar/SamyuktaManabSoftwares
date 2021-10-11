using System;

namespace GrocerySupplyManagementApp.ViewModels
{
    public class MemberTransactionView
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string Action { get; set; }
        public string ActionType { get; set; }
        public string InvoiceNo { get; set; }
        public decimal DueReceivedAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public decimal Balance { get; set; }
    }
}
