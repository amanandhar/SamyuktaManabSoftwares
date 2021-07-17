namespace GrocerySupplyManagementApp.ViewModels
{
    public class ItemView
    {
        public long Id { get; set; }
        public string Date { get; set; }
        public string BillNo { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Unit { get; set; }
        public long Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}
