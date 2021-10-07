using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class StockAdjustment
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public long ItemId { get; set; }
        public string Unit { get; set; }
        public string Action { get; set; }
        public long Quantity { get; set; }
        public decimal Price { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
