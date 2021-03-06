using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class SoldItem
    {
        public long Id { get; set; }
        public string EndOfDay { get; set; }
        public string MemberId { get; set; }
        public string InvoiceNo { get; set; }
        public long ItemId { get; set; }
        public decimal Profit { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public string CustomizedUnit { get; set; }
        public decimal CustomizedQuantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string AdjustedType { get; set; }
        public decimal AdjustedAmount { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
