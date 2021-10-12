namespace GrocerySupplyManagementApp.DTOs
{
    public class MemberTransactionFilter
    {
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string MemberId { get; set; }
        public string Action { get; set; }
    }
}
