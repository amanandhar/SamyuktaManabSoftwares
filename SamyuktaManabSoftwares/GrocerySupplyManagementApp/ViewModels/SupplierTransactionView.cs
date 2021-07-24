using System;

namespace GrocerySupplyManagementApp.ViewModels
{
    public class SupplierTransactionView
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string Action { get; set; }
        public string ActionType { get; set; }
        public string BillNo { get; set; }
        public decimal DueAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public decimal Balance { get; set; }
    }
}
