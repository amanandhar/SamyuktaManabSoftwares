using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class ShareMember
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long ContactNo { get; set; }
        public string ImagePath { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
