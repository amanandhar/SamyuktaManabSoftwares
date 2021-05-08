using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySupplyManagementApp.Entities
{
    public class SupplierTransaction
    {
        public string SupplierName { get; set; }
        public string Status { get; set; }
        public string BillNo { get; set; }
        public string RepaymentType {get; set; }
        public string Bank { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public DateTime Date { get; set; }
    }
}
