using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class UserTransaction
    {
        public long Id { get; set; }
        public DateTime EndOfDate { get; set; }
        public string InvoiceNo { get; set; }
        public string BillNo { get; set; }
        public string MemberId { get; set; }
        public string SupplierId { get; set; }
        public string Action { get; set; }
        public string ActionType { get; set; }
        public string Bank { get; set; }
        public string IncomeExpense { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal Discount { get; set; }
        public decimal VatPercent { get; set; }
        public decimal Vat { get; set; }
        public decimal DeliveryChargePercent { get; set; }
        public decimal DeliveryCharge { get; set; }
        public decimal DueAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public DateTime Date { get; set; }
    }
}
