using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class BankTransaction
    {
        public long Id { get; set; } 
        public long BankId { get; set; }
        public char Action { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string Narration { get; set; }
        public DateTime Date { get; set; }
    }
}
