using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class SupplierTransaction
    {
        public string SupplierName { get; set; }
        public string Status { get; set; }
        public string BillNo { get; set; }
        public string PaymentType {get; set; }
        public string Bank { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public DateTime Date { get; set; }
    }
}
