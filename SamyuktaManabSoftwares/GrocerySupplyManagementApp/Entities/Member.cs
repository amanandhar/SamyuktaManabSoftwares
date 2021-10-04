using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class Member
    {
        public long Id { get; set; }
        public long Counter { get; set; }
        public string MemberId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long ContactNo { get; set; }
        public string Email { get; set; }
        public string AccountNo { get; set; }
        public string ImagePath { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
