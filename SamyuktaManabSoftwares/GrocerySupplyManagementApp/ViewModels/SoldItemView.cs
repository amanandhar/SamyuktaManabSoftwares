using System;

namespace GrocerySupplyManagementApp.ViewModels
{
    public class SoldItemView
    {
        public long Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemBrand { get; set; }
        public string Unit { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
    }
}
