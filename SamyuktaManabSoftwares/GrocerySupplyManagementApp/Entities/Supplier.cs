using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySupplyManagementApp.Entities
{
    public class Supplier
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Address { get; set; }
        public long ContactNumber { get; set; }
        public string Email { get; set; }
    }
}
