namespace GrocerySupplyManagementApp.Entities
{
    public class Member
    {
        public long Id { get; set; }
        public string MemberId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long ContactNumber { get; set; }
        public string Email { get; set; }
        public string AccountNumber { get; set; }
        public decimal? Balance { get; set; }
    }
}
