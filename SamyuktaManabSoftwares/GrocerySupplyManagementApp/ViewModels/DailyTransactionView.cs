using System;

namespace GrocerySupplyManagementApp.ViewModels
{
    public class DailyTransactionView
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string Action { get; set; }
        public string ActionType { get; set; }
        public string PartyId { get; set; }
        public string PartyNumber { get; set; }
        public string BankName { get; set; }
        public decimal Amount { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
