using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySupplyManagementApp.DTOs
{
    public class SupplierTransaction
    {
        public DateTime Date { get; set; }
        public string Particulars {get; set;}
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
    }
}
