using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class IncomeExpense
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string Action { get; set; }
        public string ActionType { get; set; }
        public string BankName { get; set; }
        public string Type { get; set; }
        public string Narration { get; set; }
        public decimal ReceivedAmount { get; set; }
        public decimal PaymentAmount { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
