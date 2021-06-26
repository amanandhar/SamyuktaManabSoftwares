using System;

namespace GrocerySupplyManagementApp.DTOs
{
    public class SupplierTransactionView
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Particulars {get; set;}
        public string BillNoBank { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
    }
}
