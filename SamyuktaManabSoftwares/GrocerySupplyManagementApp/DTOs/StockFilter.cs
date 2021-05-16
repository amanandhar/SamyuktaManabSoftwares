using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySupplyManagementApp.DTOs
{
    public class StockFilter
    {
        public string ItemName { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
    }
}
