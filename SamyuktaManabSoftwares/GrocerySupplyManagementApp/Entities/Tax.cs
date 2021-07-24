using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class Tax
    {
        public decimal Discount { get; set; }
        public decimal Vat { get; set; }
        public decimal DeliveryCharge { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
