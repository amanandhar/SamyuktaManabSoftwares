using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class PosTransaction
    {
        public long Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string BillNo { get; set; }
        public string MemberId { get; set; }
        public string SupplierId { get; set; }
        public string Action { get; set; }
        public string ActionType { get; set; }
        public string Bank { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal Discount { get; set; }
        public decimal VatPercent { get; set; }
        public decimal Vat { get; set; }
        public decimal DeliveryChargePercent { get; set; }
        public decimal DeliveryCharge { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public DateTime Date { get; set; }
    }
}
