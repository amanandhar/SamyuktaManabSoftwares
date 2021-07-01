namespace GrocerySupplyManagementApp.Entities
{
    public class Supplier
    {
        public long Id { get; set; }
        public string SupplierId { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Address { get; set; }
        public long ContactNumber { get; set; }
        public string Email { get; set; }
    }
}
