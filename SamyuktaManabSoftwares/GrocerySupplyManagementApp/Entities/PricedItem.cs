using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class PricedItem
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public long ItemId { get; set; }
        public string SubCode { get; set; }
        public decimal? CustomizedQuantity { get; set; }
        public string CustomizedUnit { get; set; }
        public string Barcode { get; set; }
        public decimal ProfitPercent { get; set; }
        public decimal Profit { get; set; }
        public decimal SalesPricePerUnit { get; set; }
        public string Barcode1 { get; set; }
        public decimal ProfitPercent1 { get; set; }
        public decimal Profit1 { get; set; }
        public decimal SalesPricePerUnit1 { get; set; }
        public string ImagePath { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
