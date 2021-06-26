using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class PosInvoice
    {
        public long Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string MemberId { get; set; }
        public string Action { get; set; }
        public string PaymentType { get; set; }
        public string PaymentMethod { get; set; }
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
