using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class ItemCategory
    {
        public long Id { get; set; }
        public long Counter { get; set; }
        public string Name { get; set; }
        public string ItemCode { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
