using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class QuantitySetting
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public decimal Bag { get; set; }
        public decimal Box { get; set; }
        public decimal Packet { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
