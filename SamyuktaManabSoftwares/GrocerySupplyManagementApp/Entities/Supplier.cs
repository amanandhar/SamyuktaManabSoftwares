using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class Supplier
    {
        public long Id { get; set; }
        public long Counter { get; set; }
        public string SupplierId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long ContactNo { get; set; }
        public string Email { get; set; }
        public string Owner { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
