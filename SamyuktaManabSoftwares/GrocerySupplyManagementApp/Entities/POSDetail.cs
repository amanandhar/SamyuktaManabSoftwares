﻿namespace GrocerySupplyManagementApp.Entities
{
    public class POSDetail
    {
        public long Id { get; set; }
        public string InvoiceNo { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal Discount { get; set; }
        public decimal VatPercent { get; set; }
        public decimal Vat { get; set; }
        public decimal DeliveryChargePercent { get; set; }
        public decimal DeliveryCharge { get; set; }
    }
}