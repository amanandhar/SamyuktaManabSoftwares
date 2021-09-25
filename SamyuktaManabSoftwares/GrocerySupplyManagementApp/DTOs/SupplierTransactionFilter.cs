namespace GrocerySupplyManagementApp.DTOs
{
    public class SupplierTransactionFilter
    {
        public string SupplierId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string Action { get; set; }
    }
}
