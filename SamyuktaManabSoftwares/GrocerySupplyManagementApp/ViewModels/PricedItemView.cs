namespace GrocerySupplyManagementApp.ViewModels
{
    public class PricedItemView
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string SubCode { get; set; }
        public string Name { get; set; }
        public decimal CustomizedQuantity { get; set; }
        public decimal Stock { get; set; }
    }
}
