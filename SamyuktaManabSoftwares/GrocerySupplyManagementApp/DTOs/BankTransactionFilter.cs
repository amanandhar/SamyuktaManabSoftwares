namespace GrocerySupplyManagementApp.DTOs
{
    public class BankTransactionFilter
    {
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public char Type { get; set; }
        public string Action { get; set; }
        public long? BankId { get; set; }
    }
}
