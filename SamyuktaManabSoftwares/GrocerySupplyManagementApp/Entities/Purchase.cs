using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySupplyManagementApp.Entities
{
    public class Purchase
    {
        public long Id { get; set; }
        public long PurchaseId { get; set; }
        public string ItemName { get; set; }
        public string BrandName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public string BillNo { get; set; }
    }
}
