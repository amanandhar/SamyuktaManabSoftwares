using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class FiscalYear
    {
        public string StartingInvoiceNo { get; set; }
        public string StartingBillNo { get; set; }
        public string StartingDate { get; set; } 
        public string Year { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
