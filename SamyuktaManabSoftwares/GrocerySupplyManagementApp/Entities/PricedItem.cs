using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class PricedItem
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public long ItemId { get; set; }
        public decimal ProfitPercent { get; set; }
        public decimal Profit { get; set; }
        public decimal SalesPricePerUnit { get; set; }
        public string Barcode { get; set; }
        public string ImagePath { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
