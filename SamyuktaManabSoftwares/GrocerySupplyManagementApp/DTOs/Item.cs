namespace GrocerySupplyManagementApp.DTOs
{
    public class Item
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Unit { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellPrice { get; set; }
    }
}
