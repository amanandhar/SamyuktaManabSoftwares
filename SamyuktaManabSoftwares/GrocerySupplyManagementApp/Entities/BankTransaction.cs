using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class BankTransaction
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public long BankId { get; set; }
        public long TransactionId { get; set; }
        public char Action { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string Narration { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
