using System;

namespace GrocerySupplyManagementApp.Entities
{
    public class Setting
    {
        public long Id { get; set; }
        public string StartingInvoiceNo { get; set; }
        public string StartingBillNo { get; set; }
        public string StartingDate { get; set; }
        public string FiscalYear { get; set; }
        public decimal Discount { get; set; }
        public decimal Vat { get; set; }
        public decimal DeliveryCharge { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
