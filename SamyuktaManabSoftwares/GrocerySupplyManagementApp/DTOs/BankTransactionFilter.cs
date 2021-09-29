namespace GrocerySupplyManagementApp.DTOs
{
    public class BankTransactionFilter
    {
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public char? Action { get; set; }
        public string Narration { get; set; }
        public long? BankId { get; set; }
    }
}
