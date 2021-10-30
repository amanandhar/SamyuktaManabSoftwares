namespace GrocerySupplyManagementApp.ViewModels
{
    public class BankTransactionView
    {
        public long Id { get; set; }
        public long TransactionId { get; set; }
        public string EndOfDay { get; set; }
        public string Description { get; set; }
        public string Narration { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
    }
}
