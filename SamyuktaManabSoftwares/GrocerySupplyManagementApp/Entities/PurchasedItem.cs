using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class PurchasedItem
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string SupplierId { get; set; }
        public string BillNo { get; set; }
        public bool IsBonus { get; set; }
        public long ItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
