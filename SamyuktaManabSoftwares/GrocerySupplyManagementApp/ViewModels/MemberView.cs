using System;

namespace GrocerySupplyManagementApp.ViewModels
{
    public class MemberView
    {
        public long Id { get; set; }
        public long Counter { get; set; }
        public string MemberId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long ContactNo { get; set; }
        public string Email { get; set; }
        public string AccountNo { get; set; }
        public DateTime Date { get; set; }
        public decimal Balance { get; set; }
    }
}
