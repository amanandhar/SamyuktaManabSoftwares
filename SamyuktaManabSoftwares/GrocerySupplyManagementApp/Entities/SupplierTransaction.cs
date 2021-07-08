using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class SupplierTransaction
    {
        public long Id { get; set; }
        public string SupplierName { get; set; }
        public string BillNo { get; set; }
        public string Action { get; set; }
        public string ActionType {get; set; }
        public string Bank { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public DateTime Date { get; set; }
    }
}
