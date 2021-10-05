namespace GrocerySupplyManagementApp.DTOs
{
    public class ExcelField
    {
        public long Order { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
        public bool IsColumn { get; set; }
    }
}
