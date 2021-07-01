namespace GrocerySupplyManagementApp.Entities
{
    public class PosSoldItem
    {
        public long Id { get; set; }
        public string InvoiceNo { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemBrand { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
