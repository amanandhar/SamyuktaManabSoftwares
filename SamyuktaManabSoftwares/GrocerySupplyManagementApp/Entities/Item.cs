using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class Item
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal Threshold { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
