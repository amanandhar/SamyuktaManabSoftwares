using System;

namespace GrocerySupplyManagementApp.ViewModels
{
    public class SoldItemView
    {
        public long Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal Profit { get; set; }
        public string Unit { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal ItemDiscount { get; set; }
        public decimal Volume { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
