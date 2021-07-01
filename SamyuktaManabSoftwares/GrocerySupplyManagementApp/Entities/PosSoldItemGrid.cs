using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class PosSoldItemGrid
    {
        public long Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemBrand { get; set; }
        public string Unit { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
    }
}
