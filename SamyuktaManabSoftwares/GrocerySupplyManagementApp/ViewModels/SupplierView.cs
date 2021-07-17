using System;

namespace GrocerySupplyManagementApp.ViewModels
{
    public class SupplierView
    {
        public long Id { get; set; }
        public string SupplierId { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public decimal Balance { get; set; }
    }
}
